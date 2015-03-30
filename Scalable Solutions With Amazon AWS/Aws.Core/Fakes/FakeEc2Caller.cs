using System;
using System.Collections.Generic;
using System.Linq;
using Aws.Core.Abstract;
using Aws.Core.Models;
using Faker;

namespace Aws.Core.Fakes
{
    public class FakeEc2Caller : IEc2Caller
    {
        private Dictionary<AwsRegionLocations, string> regionNames = new Dictionary<AwsRegionLocations, string>();

        public FakeEc2Caller()
        {
            regionNames.Add(AwsRegionLocations.UsEast, "us-east-1");
            regionNames.Add(AwsRegionLocations.UsWest1, "us-west-1");
            regionNames.Add(AwsRegionLocations.UsWest2, "us-west-2");
            regionNames.Add(AwsRegionLocations.EuWest, "eu-west-1");
            regionNames.Add(AwsRegionLocations.SaEast, "sa-east-1");
            regionNames.Add(AwsRegionLocations.ApNortheast, "ap-northeast-1");
            regionNames.Add(AwsRegionLocations.ApSoutheast1, "ap-southeast-1");
            regionNames.Add(AwsRegionLocations.ApSoutheast2, "ap-southeast-2");
        }

        public RegionDetails GetRegionData(AwsRegionLocations region)
        {
            return new RegionDetails()
            {
                Name = regionNames[region],
                Region = region,
                Instances = CreateSomeRandomInstances().ToList()
            };
        }

        public void LaunchInstance(AwsRegionLocations region, Action<AwsRegionLocations> instanceLaunched)
        {
            instanceLaunched(region);
        }

        public void TerminateInstance(AwsRegionLocations region, Action<AwsRegionLocations> instanceTerminated)
        {
            instanceTerminated(region);
        }

        private IEnumerable<InstanceInfo> CreateSomeRandomInstances()
        {
            for (int i = 0; i < NumberFaker.Number(10, 20); i++)
            {
                yield return new InstanceInfo()
                {
                    InstanceId = "i-" + StringFaker.AlphaNumeric(8).ToLower(),
                    IpAddress = IpAddressFaker.IpAddress(),
                    Status = NumberFaker.Number(1, 10) < 9 ? InstanceStatuses.Running : InstanceStatuses.Pending,
                    WorkerInfo = new WorkerInfo()
                    {
                        WorkerOnline = false
                    }
                };
            }
        }
    }
}