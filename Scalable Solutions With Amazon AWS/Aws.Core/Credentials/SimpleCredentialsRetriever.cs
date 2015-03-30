using Amazon.Runtime;

namespace Aws.Core.Credentials
{
    public class SimpleCredentialsRetriever : ICredentialsRetriever
    {
        private readonly string _accessKey;
        private readonly string _secretKey;

        public SimpleCredentialsRetriever(string accessKey, string secretKey)
        {
            _accessKey = accessKey;
            _secretKey = secretKey;
        }

        public AWSCredentials GetCredentials()
        {
            return new BasicAWSCredentials(_accessKey, _secretKey);
        }

        public bool CredentialsExist()
        {
            return !(_accessKey == "YourAccessKey" && _secretKey == "YourSecretKey");
        }
    }
}