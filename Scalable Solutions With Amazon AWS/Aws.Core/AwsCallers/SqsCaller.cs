using System;
using System.Collections.Generic;
using System.Linq;
using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using Aws.Core.Abstract;
using Aws.Core.Credentials;
using Aws.Core.Models;

namespace Aws.Core.AwsCallers
{
    public class SqsCaller : ISqsCaller
    {
        private readonly string queueUrl;
        private readonly AWSCredentials credentials;
        private readonly AmazonSQSClient client;

        public SqsCaller(ICredentialsRetriever credentialsRetriever, string queueUrl)
        {
            this.queueUrl = queueUrl;
            credentials = credentialsRetriever.GetCredentials();
            this.client = new AmazonSQSClient(credentials, RegionEndpoint.USEast1);
        }

        public void Enqueue(string message)
        {
            // Send the request for the message to be put into the queue at url
            SendMessageResponse sendMessageResponse = client.SendMessage(queueUrl, message);
        }

        public IEnumerable<SqsMessage> GetMessages()
        {
            // Request all the messages that are in the queue and yield them out
            var response = client.ReceiveMessage(queueUrl);
            foreach (var message in response.Messages)
            {
                yield return new SqsMessage() {Message = message.Body, ReceiptHandle = message.ReceiptHandle};
            }
        }

        public void DeleteMessage(string receiptHandle)
        {
            // Delete the message with this receipt handle.
            client.DeleteMessage(queueUrl, receiptHandle);
        }
    }
}