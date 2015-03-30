namespace Aws.Worker.Remote
{
    public interface IRemoteService
    {
        string GetData();
        bool HasData();
    }
}