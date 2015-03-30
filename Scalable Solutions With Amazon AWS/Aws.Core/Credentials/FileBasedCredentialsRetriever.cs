using System;
using System.IO;
using Amazon.Runtime;

namespace Aws.Core.Credentials
{
    public class FileBasedCredentialsRetriever : ICredentialsRetriever
    {
        private readonly string credentialsFilePath;

        public FileBasedCredentialsRetriever(string credentialsFilePath)
        {
            this.credentialsFilePath = credentialsFilePath;
        }

        public AWSCredentials GetCredentials()
        {
            return GetCredentials(credentialsFilePath);
        }

        public bool CredentialsExist()
        {
            return (File.Exists(credentialsFilePath));
        }

        private static AWSCredentials GetCredentials(string credentialsFilePath)
        {
            if (File.Exists(credentialsFilePath))
            {
                var credentialsArray = File.ReadAllText(credentialsFilePath).Split(',');
                return new BasicAWSCredentials(credentialsArray[0], credentialsArray[1]);
            }
            Console.WriteLine("Credentials not found. You will need to enter your own credentials for this demo to work.");
            Console.WriteLine("Enter access key:");
            var accessKey = Console.ReadLine();
            Console.WriteLine("Enter secret key:");
            var secretKey = Console.ReadLine();
            return new BasicAWSCredentials(accessKey, secretKey);
        }
    }
}