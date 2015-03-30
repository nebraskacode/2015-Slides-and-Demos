namespace Aws.Worker.Output
{
    public interface IOutputQueue
    {
        void Enqueue(string data);
    }
}