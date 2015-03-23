using MovieFanatic.Domain;

namespace MovieFanatic.Web.Infrastructure.Authentication
{
    public class Authenticator : IAuthenticator
    {
        public bool IsAuthenticated()
        {
            return true;
        }

        public string GetCurrentUser()
        {
            //We'd generally use Forms Authentication here, but since we're not really authenticating we'll just fake it up.
            return "Mike";
        }
    }
}