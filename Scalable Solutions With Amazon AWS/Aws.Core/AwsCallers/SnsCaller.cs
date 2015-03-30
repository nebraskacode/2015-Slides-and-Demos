using System;
using System.Collections.Generic;
using System.Linq;
using Amazon;
using Amazon.Runtime;
using Amazon.SimpleNotificationService;
using Aws.Core.Credentials;

namespace Aws.Core.AwsCallers
{
    public class SnsCaller
    {
        private readonly AWSCredentials credentials;
        private readonly AmazonSimpleNotificationServiceClient client;

        public SnsCaller(ICredentialsRetriever credentialsRetriever)
        {
            credentials = credentialsRetriever.GetCredentials();
            client = new AmazonSimpleNotificationServiceClient(credentials, RegionEndpoint.USEast1);
        }

        public void SendMessage()
        {
            
        }
    }
}