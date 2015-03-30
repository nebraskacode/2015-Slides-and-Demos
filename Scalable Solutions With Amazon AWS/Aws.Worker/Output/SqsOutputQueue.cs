using System;
using System.Collections.Generic;
using System.Linq;
using Aws.Core.AwsCallers;

namespace Aws.Worker.Output
{
    public class SqsOutputQueue : IOutputQueue
    {
        private readonly SqsCaller sqsCaller;

        public SqsOutputQueue(SqsCaller sqsCaller)
        {
            this.sqsCaller = sqsCaller;
        }

        public void Enqueue(string data)
        {
            sqsCaller.Enqueue(data);
        }
    }
}