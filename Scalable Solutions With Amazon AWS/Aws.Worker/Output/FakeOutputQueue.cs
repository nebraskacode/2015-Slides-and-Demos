using System;
using System.Collections.Generic;
using System.Linq;

namespace Aws.Worker.Output
{
    public class FakeOutputQueue : IOutputQueue
    {
        public FakeOutputQueue()
        {
            
        }

        public void Enqueue(string data)
        {
        }
    }
}