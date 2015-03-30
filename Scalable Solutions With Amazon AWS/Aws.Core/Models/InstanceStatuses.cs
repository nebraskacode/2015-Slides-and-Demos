namespace Aws.Core.Models
{
    // Referenced documentation: http://docs.aws.amazon.com/AWSEC2/latest/APIReference/ApiReference-ItemType-InstanceStateType.html
    public enum InstanceStatuses : ushort
    {
        Pending = 0,
        Running = 16,
        ShuttingDown = 32,
        Terminated = 48,
        Stopping = 64,
        Stopped = 80
    }
}