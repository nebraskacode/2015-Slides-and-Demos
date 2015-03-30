using System.Collections.Concurrent;
using System.IO;
using Amazon;
using Amazon.EC2;
using Amazon.Runtime;
using Amazon.S3;
using Aws.Core.Credentials;
using Aws.Core.Extensions;
using Aws.Core.Models;

namespace Aws.Core.AwsCallers
{
    public class S3Caller
    {
        private readonly AWSCredentials credentials;
        private ConcurrentDictionary<AwsRegionLocations, IAmazonS3> s3Clients = new ConcurrentDictionary<AwsRegionLocations, IAmazonS3>();

        public S3Caller(ICredentialsRetriever credentialsRetriever)
        {
            this.credentials = credentialsRetriever.GetCredentials();
        }

        public byte[] DownloadData(string bucketName, string keyName, AwsRegionLocations region)
        {
            var regionEndpoint = region.ToAwsRegionEndpoint();

            // Get an Ec2Client for the current region
            var client = s3Clients.GetOrAdd(region, r => AWSClientFactory.CreateAmazonS3Client(credentials, regionEndpoint));

            // download the data
            using (var stream = client.GetObject(bucketName, keyName).ResponseStream)
            {
                return ReadFully(stream);
            }
        }

        // Taken from Stack Overflow, http://stackoverflow.com/a/6586039
        private static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}