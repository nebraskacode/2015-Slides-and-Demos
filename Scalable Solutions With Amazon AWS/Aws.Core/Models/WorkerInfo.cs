using System;
using System.Collections.Generic;
using System.Linq;

namespace Aws.Core.Models
{
    public class WorkerInfo
    {
        public bool WorkerOnline { get; set; }
        public int WorkerVersion { get; set; }
        public int WorkerLoad { get; set; } 
    }
}