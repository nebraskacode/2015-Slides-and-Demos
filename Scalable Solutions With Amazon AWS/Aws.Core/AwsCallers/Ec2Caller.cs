using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;
using Aws.Core.Abstract;
using Aws.Core.Credentials;
using Aws.Core.Extensions;
using Aws.Core.Models;

namespace Aws.Core.AwsCallers
{
    public class Ec2Caller : IEc2Caller
    {
        private readonly string amiName;
        private readonly string securityGroupName;
        private readonly string keyPairName;
        private readonly AWSCredentials credentials;
        private ConcurrentDictionary<AwsRegionLocations, IAmazonEC2> ec2Clients = new ConcurrentDictionary<AwsRegionLocations, IAmazonEC2>();
        private ConcurrentQueue<AwsRegionLocations> instancesToBeLaunched = new ConcurrentQueue<AwsRegionLocations>();
        private bool instanceCurrentlyBeingLaunched = false;

        public Ec2Caller(ICredentialsRetriever credentialsRetriever, string amiName, string securityGroupName, string keyPairName)
        {
            this.amiName = amiName;
            this.securityGroupName = securityGroupName;
            this.keyPairName = keyPairName;
            credentials = credentialsRetriever.GetCredentials();
        }

        public RegionDetails GetRegionData(AwsRegionLocations region)
        {
            var regionEndpoint = region.ToAwsRegionEndpoint();

            // Get an Ec2Client for the current region
            var client = ec2Clients.GetOrAdd(region, r => AWSClientFactory.CreateAmazonEC2Client(credentials, regionEndpoint));

            // Get instances within the region
            // Start by creating the request
            var request = new DescribeInstancesRequest();

            // Add a filter to the request so that it only returns instances that are either in "Running" or "Pending" state.
            request.Filters.Add(new Filter("instance-state-code", new List<string>()
            {
                ((ushort)InstanceStatuses.Running).ToString(),
                ((ushort)InstanceStatuses.Pending).ToString()
            }));

            // Send the request to Amazon
            var reservations = client.DescribeInstances(request).Reservations;

            return new RegionDetails()
            {
                Name = regionEndpoint.SystemName,
                Region = region,
                Instances = reservations.SelectMany(x => x.Instances).Select(x => x.ToInstanceInfo()).ToList()
            };
        }

        public string EnsureSecurityGroupExists(AwsRegionLocations region)
        {
            var regionEndpoint = region.ToAwsRegionEndpoint();

            // Get an Ec2Client for the current region
            var client = ec2Clients.GetOrAdd(region, r => AWSClientFactory.CreateAmazonEC2Client(credentials, regionEndpoint));

            // Find the VPC ID for this region
            var vpcId = client.DescribeVpcs().Vpcs.Single().VpcId;

            // Does the security group with our preset name exist?
            var matchingGroups = client.DescribeSecurityGroups().SecurityGroups.Where(x => x.GroupName == securityGroupName).ToList();
            if (matchingGroups.Any())
            {
                // If it exists, assert that it has the same VPC ID as the one we found earlier
                if (matchingGroups.Single().VpcId != vpcId)
                {
                    throw new Exception("Security Group already exists with invalid VPC.");
                }
                return matchingGroups.Single().GroupId;
            }
            else
            {
                // It does not exist, so create it.
                return CreateSecurityGroup(client, vpcId, securityGroupName);
            }
        }

        private static string CreateSecurityGroup(IAmazonEC2 client, string vpcId, string groupName)
        {
            // Create a new empty group
            var newSgRequest = new CreateSecurityGroupRequest()
            {
                GroupName = groupName,
                Description = "Security group for AWS Talk",
                VpcId = vpcId
            };

            // Get a handle to the newly created group
            var newSgResponse = client.CreateSecurityGroup(newSgRequest);
            var groups = new List<string>() { newSgResponse.GroupId };
            var createdSgRequest = new DescribeSecurityGroupsRequest() { GroupIds = groups };
            var createdSgResponse = client.DescribeSecurityGroups(createdSgRequest);
            SecurityGroup theNewGroup = createdSgResponse.SecurityGroups[0];

            // Add permissions to the group
            var ingressRequest = new AuthorizeSecurityGroupIngressRequest();
            ingressRequest.GroupId = theNewGroup.GroupId;
            ingressRequest.IpPermissions.Add(new IpPermission() { IpProtocol = "tcp", FromPort = 3389, ToPort = 3389, IpRanges = new List<string>() { "0.0.0.0/0" } }); // RDP
            ingressRequest.IpPermissions.Add(new IpPermission() { IpProtocol = "tcp", FromPort = 9999, ToPort = 9999, IpRanges = new List<string>() { "0.0.0.0/0" } }); // Worker API

            client.AuthorizeSecurityGroupIngress(ingressRequest);

            return newSgResponse.GroupId;
        }

        public static string GetAmiId(IAmazonEC2 client, string amiName)
        {
            return client.DescribeImages().Images.Single(x => x.Name == amiName).ImageId;
        }

        public void LaunchInstance(AwsRegionLocations region, Action<AwsRegionLocations> instanceLaunched)
        {
            // Wrap instance creation to ensure that only one is being launched simultaneously. This should be refactored but will not be due to time constraints.
            if (!instanceCurrentlyBeingLaunched)
            {
                instanceCurrentlyBeingLaunched = true;
                CreateAndLaunchInstance(region);
                instanceLaunched(region);
                while (!instancesToBeLaunched.IsEmpty)
                {
                    AwsRegionLocations nextRegion;
                    if (instancesToBeLaunched.TryDequeue(out nextRegion))
                    {
                        CreateAndLaunchInstance(nextRegion);
                        instanceLaunched(nextRegion);
                    }
                }
                instanceCurrentlyBeingLaunched = false;
            }
            else
            {
                instancesToBeLaunched.Enqueue(region);
            }
        }

        public void TerminateInstance(AwsRegionLocations region, Action<AwsRegionLocations> instanceTerminated)
        {
            var newestInstanceInRegion = FindNewestInstanceId(region);
            if (newestInstanceInRegion != null)
            {
                TerminateInstance(region, newestInstanceInRegion);
                instanceTerminated(region);
            }
        }

        private string FindNewestInstanceId(AwsRegionLocations region)
        {
            var client = ec2Clients.GetOrAdd(region, r => AWSClientFactory.CreateAmazonEC2Client(credentials, region.ToAwsRegionEndpoint()));

            // Get instances within the region
            // Start by creating the request
            var request = new DescribeInstancesRequest();

            // Add a filter to the request so that it only returns instances that are either in "Running" state.
            request.Filters.Add(new Filter("instance-state-code", new List<string>()
            {
                ((ushort)InstanceStatuses.Running).ToString(),
            }));

            // Send the request to Amazon
            var reservations = client.DescribeInstances(request).Reservations;

            var instances = reservations.SelectMany(x => x.Instances);
            if (instances.Any())
            {
                var newestInstance = instances.OrderByDescending(i => i.LaunchTime).First();
                return newestInstance.InstanceId;
            }
            return null;
        }

        private void TerminateInstance(AwsRegionLocations region, string instanceId)
        {
            var client = ec2Clients.GetOrAdd(region, r => AWSClientFactory.CreateAmazonEC2Client(credentials, region.ToAwsRegionEndpoint()));

            var deleteRequest = new TerminateInstancesRequest()
            {
                InstanceIds = new List<string>() { instanceId }
            };

            client.TerminateInstances(deleteRequest);
        }

        private void CreateAndLaunchInstance(AwsRegionLocations region)
        {
            // Get an Ec2Client for the current region
            var client = ec2Clients.GetOrAdd(region, r => AWSClientFactory.CreateAmazonEC2Client(credentials, region.ToAwsRegionEndpoint()));

            var securityGroupId = EnsureSecurityGroupExists(region);
            var availableSubnets = client.DescribeSubnets().Subnets.OrderByDescending(x => x.AvailableIpAddressCount);
            var networkSpecification = new InstanceNetworkInterfaceSpecification()
            {
                DeviceIndex = 0,
                SubnetId = availableSubnets.First().SubnetId,
                Groups = new List<string>() { securityGroupId },
                AssociatePublicIpAddress = true
            };
            var networkSpecifications = new List<InstanceNetworkInterfaceSpecification>() { networkSpecification };

            var launchRequest = new RunInstancesRequest()
            {
                ImageId = GetAmiId(client, amiName),
                InstanceType = "t2.micro",
                MinCount = 1,
                MaxCount = 1,
                KeyName = keyPairName,
                NetworkInterfaces = networkSpecifications
            };

            client.RunInstances(launchRequest);
        }
    }
}