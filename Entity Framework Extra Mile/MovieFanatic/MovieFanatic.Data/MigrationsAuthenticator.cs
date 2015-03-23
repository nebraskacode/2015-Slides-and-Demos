using MovieFanatic.Domain;

namespace MovieFanatic.Data
{
    public class MigrationsAuthenticator : IAuthenticator
    {
        public bool IsAuthenticated()
        {
            return true;
        }

        public string GetCurrentUser()
        {
            return "Migrations";
        }
    }
}