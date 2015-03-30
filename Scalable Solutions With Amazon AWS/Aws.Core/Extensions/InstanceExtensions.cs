using Amazon.EC2.Model;
using Aws.Core.Models;

namespace Aws.Core.Extensions
{
    public static class InstanceExtensions
    {
        public static InstanceInfo ToInstanceInfo(this Instance instance)
        {
            return new InstanceInfo()
            {
                InstanceId = instance.InstanceId,
                IpAddress = instance.PublicIpAddress,
                Status = (InstanceStatuses)instance.State.Code
            };
        }
    }
}