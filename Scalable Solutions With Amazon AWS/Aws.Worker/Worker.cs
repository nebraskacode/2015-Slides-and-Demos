using System;
using System.Collections.Generic;
using System.Linq;
using Aws.Core.AwsCallers;
using Aws.Core.Credentials;
using Aws.Worker.Output;
using Aws.Worker.Remote;

namespace Aws.Worker
{
    public class Worker
    {
        private readonly IRemoteService remoteService;
        private readonly IOutputQueue outputQueue;

        // Bastard injection, so that these details don't get mixed into the WebAPI selfhost and topshelf code.
        public Worker()
            : this(new FakeRemoteService(), 
            new SqsOutputQueue(
                new SqsCaller(
                    new FileBasedCredentialsRetriever(@"C:\aws-talk\aws-talk-credentials.txt"),
                    "https://sqs.us-east-1.amazonaws.com/025631894481/aws-talk"
                    )))
        { }

        public Worker(IRemoteService remoteService, IOutputQueue outputQueue)
        {
            this.remoteService = remoteService;
            this.outputQueue = outputQueue;
        }

        public void DoWork()
        {
            if (remoteService.HasData())
            {
                outputQueue.Enqueue(remoteService.GetData());
            }
        }
    }
}