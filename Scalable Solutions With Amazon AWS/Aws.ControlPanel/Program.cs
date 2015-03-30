using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aws.Core.AwsCallers;
using Aws.Core.Credentials;
using Aws.Core.Fakes;
using Aws.Core.WorkerCallers;

namespace Aws.ControlPanel
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Keeping things simple by not using DI here

            //ICredentialsRetriever credentialsRetriever = new FileBasedCredentialsRetriever(@"C:\aws-talk\aws-talk-credentials.txt");
            ICredentialsRetriever credentialsRetriever = new SimpleCredentialsRetriever("YourAccessKey", "YourSecretKey");

            if (!credentialsRetriever.CredentialsExist())
            {
                throw new Exception("AWS credentials not found. Please use SimpleCredentialsRetriever (above) to enter your AWS credentials)");
            }
            
            var s3Bucket = "aws-talk";
            var workerAmi = "aws-talk-base";
            var securityGroup = "aws-talk";
            var keyPair = "aws-talk";
            var queueUrl = "https://sqs.us-east-1.amazonaws.com/025631894481/aws-talk";

            var ec2Caller = new Ec2Caller(credentialsRetriever, workerAmi, securityGroup, keyPair);
            var sqsCaller = new SqsCaller(credentialsRetriever, queueUrl);
            //var ec2Caller = new FakeEc2Caller();
            var workerCaller = new WorkerCaller(credentialsRetriever, s3Bucket);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(ec2Caller, sqsCaller, workerCaller));
        }
    }
}
