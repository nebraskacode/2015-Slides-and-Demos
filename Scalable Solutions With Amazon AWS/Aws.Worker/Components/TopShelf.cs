using System;
using System.Collections.Generic;
using System.Linq;
using Topshelf;
using Topshelf.ServiceConfigurators;

namespace Aws.Worker.Components
{
    public static class TopShelf
    {
        public static void LaunchAsService()
        {
            // Configure the application to run as a windows service
            HostFactory.Run(x =>
            {
                // Point to WebApiService as the class containing the application
                x.Service((ServiceConfigurator<WebApiSelfhost> s) =>
                {
                    s.ConstructUsing(() => new WebApiSelfhost());
                    s.WhenStarted(svc => svc.Start());
                    s.WhenStopped(svc => svc.Stop());
                });

                // Configure the parameters of the windows service
                x.RunAsLocalSystem();
                x.SetDescription("Worker. Demonstrated in AWS talk given by Ondrej Balas");
                x.SetDisplayName("Worker (AWS Talk)");
                x.SetServiceName("WorkerAws");
            });
        }
    }
}