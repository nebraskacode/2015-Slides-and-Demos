using Amazon.Runtime;

namespace Aws.Core.Credentials
{
    public interface ICredentialsRetriever
    {
        AWSCredentials GetCredentials();
        bool CredentialsExist();
    }
}