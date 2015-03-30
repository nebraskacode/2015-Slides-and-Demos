namespace Aws.Core.Models
{
    public class InstanceInfo
    {
        public string InstanceId { get; set; }
        public InstanceStatuses Status { get; set; }
        public string IpAddress { get; set; }
        public WorkerInfo WorkerInfo { get; set; }
    }
}