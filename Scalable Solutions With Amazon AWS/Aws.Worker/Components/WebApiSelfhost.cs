using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace Aws.Worker.Components
{
    public class WebApiSelfhost
    {
        private bool serviceStarted = false;
        private bool isRunning = false;

        public bool Start()
        {
            serviceStarted = true;
            Task.Factory.StartNew(ApiThread);
            return true;
        }

        private void ApiThread()
        {
            // Start the Selfhosted WebAPI. Read the apiUrl from the config file
            var listenUrl = ConfigurationManager.AppSettings["ApiUrl"];
            Console.WriteLine("Launching WebAPI at " + listenUrl);
            // If this line generates an error, you can use the netsh command to allow the port to be listened on by non-administrators
            // Source: http://stackoverflow.com/questions/3682287/why-wont-my-windows-service-that-is-hosting-a-wcf-service-run-under-localservic
            // Example: netsh http add urlacl url=http://*:9999/ user=Everyone

            using (WebApp.Start<Startup>(listenUrl))
            {
                isRunning = true;

                // Keep the thread alive so that application doesn't exit
                var worker = new Worker();
                while (serviceStarted)
                {
                    worker.DoWork();
                    Thread.Sleep(100);
                }
            }
            isRunning = false;
        }

        public bool Stop()
        {
            serviceStarted = false;

            // Wait for WebAPI to exit
            while (isRunning)
            {
                Thread.Sleep(100);
            }
            return true;
        }
 
    }
}