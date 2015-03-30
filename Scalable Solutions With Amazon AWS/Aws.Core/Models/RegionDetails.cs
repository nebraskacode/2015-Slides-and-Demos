using System.Collections.Generic;
using System.Linq;

namespace Aws.Core.Models
{
    public class RegionDetails
    {
        public string Name { get; set; }
        public AwsRegionLocations Region { get; set; }
        public List<InstanceInfo> Instances { get; set; }
        public int RunningInstancesCount { get { return Instances != null ? Instances.Count(x => x.Status == InstanceStatuses.Running) : 0; } }
        public int PendingInstancesCount { get { return Instances != null ? Instances.Count(x => x.Status == InstanceStatuses.Pending) : 0; } }

        public RegionDetails()
        {
            Instances = new List<InstanceInfo>();
        }
    }
}