using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Topshelf;
using Topshelf.ServiceConfigurators;

namespace Aws.Worker
{
    class Program
    {
        public const int Version = 101;

        static void Main(string[] args)
        {
            Console.WriteLine("Version {0}", Version);
            
            Components.TopShelf.LaunchAsService();
        }
    }
}
