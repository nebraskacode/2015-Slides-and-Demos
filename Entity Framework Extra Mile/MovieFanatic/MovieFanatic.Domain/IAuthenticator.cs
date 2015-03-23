namespace MovieFanatic.Domain
{
    public interface IAuthenticator
    {
        bool IsAuthenticated();
        string GetCurrentUser();
    }
}