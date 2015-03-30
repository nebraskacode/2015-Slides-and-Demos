using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Aws.Worker.Controllers
{
    public class InstrumentationController : ApiController
    {
        public int GetVersion()
        {
            return Program.Version;
        }

        [HttpPost]
        public HttpResponseMessage Update(string accessKey, string secretKey, string s3Bucket, string s3Path)
        {
            Task.Factory.StartNew(() => ProcessUpdate(accessKey, secretKey, s3Bucket, s3Path));
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        private void ProcessUpdate(string accessKey, string secretKey, string s3Bucket, string s3Path)
        {
            var myExe = Assembly.GetExecutingAssembly().Location;
            var myDir = Path.GetDirectoryName(myExe);

            Console.WriteLine("I will be updating with args:");
            Console.WriteLine("-f: " + myDir);
            Console.WriteLine("-e: " + myExe);
            Console.WriteLine();
            Console.WriteLine("Press enter to update");

            Process.Start(ConfigurationManager.AppSettings["UpdaterPath"],
                string.Format(@"-a{0} -s{1} -b{2} -r{3} -f""{4}"" -e""{5}"" -v=true",
                accessKey,
                secretKey,
                s3Bucket,
                s3Path,
                myDir,
                myExe
            ));

            Thread.Sleep(500);
            Environment.Exit(0);
        }
    }
}