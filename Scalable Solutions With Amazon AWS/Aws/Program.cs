using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.Runtime;
using Amazon.SimpleDB;
using Amazon.SimpleDB.Model;
using Amazon.SQS;
using Amazon.SQS.Model;
using Aws.Core;
using Aws.Core.AwsCallers;
using Aws.Core.Credentials;
using Aws.Core.Models;

namespace Aws
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get credentials from a file
            FileBasedCredentialsRetriever credentials = new FileBasedCredentialsRetriever(@"C:\aws-talk\aws-talk-credentials.txt");
            AWSCredentials ec2Credentials = credentials.GetCredentials();

            ReadFromSimpleDb(ec2Credentials);

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        static void GetInstances(AWSCredentials credentials)
        {
            IAmazonEC2 client = AWSClientFactory.CreateAmazonEC2Client(credentials, RegionEndpoint.USEast1);

            DescribeInstancesRequest request = new DescribeInstancesRequest();
            request.Filters.Add(new Filter("instance-state-code", new List<string>() { "0", "16" }));

            DescribeInstancesResponse describeInstancesResponse = client.DescribeInstances();
            List<Reservation> reservations = describeInstancesResponse.Reservations;

            foreach (Instance instance in reservations.SelectMany(x => x.Instances))
            {
                Console.WriteLine("Instance with ID {0} is currently {1}", instance.InstanceId, instance.State.Name);
            }
        }

        static void WriteToQueue(AWSCredentials credentials)
        {
            AmazonSQSClient client = new AmazonSQSClient(credentials, RegionEndpoint.USEast1);

            string message = "my message";
            string queueUrl = "https://sqs.us-east-1.amazonaws.com/025631894481/aws-talk";

            SendMessageResponse sendMessageResponse = client.SendMessage(queueUrl, message);
        }

        static void ReadFromQueue(AWSCredentials credentials)
        {
            AmazonSQSClient client = new AmazonSQSClient(credentials, RegionEndpoint.USEast1);

            string queueUrl = "https://sqs.us-east-1.amazonaws.com/025631894481/aws-talk";

            ReceiveMessageRequest request = new ReceiveMessageRequest(queueUrl);
            request.MaxNumberOfMessages = 1;
            ReceiveMessageResponse response = client.ReceiveMessage(request);

            foreach (var message in response.Messages)
            {
                // Do something with the message
            }
        }

        static void WriteToSimpleDb(AWSCredentials credentials)
        {
            var client = new AmazonSimpleDBClient(credentials, RegionEndpoint.USEast1);

            var request = new CreateDomainRequest("aws-talk");
            var response = client.CreateDomain(request);

            var putData = new PutAttributesRequest("aws-talk", "products/" + Guid.NewGuid().ToString(),
                new List<ReplaceableAttribute>()
                {
                    new ReplaceableAttribute("Name", "Couch", true),
                    new ReplaceableAttribute("Price", "20", true)
                });
            client.PutAttributes(putData);
        }

        static void ReadFromSimpleDb(AWSCredentials credentials)
        {
            var client = new AmazonSimpleDBClient(credentials, RegionEndpoint.USEast1);

            // attribute names are case sensitive
            // comparisons are lexicographical. no numeric comparisons exist
            var request = new SelectRequest("select * from `aws-talk` WHERE `Price` > '01'");
            var response = client.Select(request);
            foreach (var item in response.Items)
            {
                Console.WriteLine("Item {0} has attributes: {1}",
                    item.Name, String.Join(" ; ", item.Attributes.Select(a => string.Format("{0}={1}", a.Name, a.Value))));
            }
        }
    }
}
