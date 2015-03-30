//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Aws.Core.Models
//{
//    public class DetailedRegion
//    {
//        public string Name { get; set; }
//        public AwsRegionLocations Region { get; set; }
//        public List<InstanceInfo> Instances { get; private set; }
//        public int RunningInstancesCount { get { return Instances != null ? Instances.Count(x => x.Status == InstanceStatuses.Running) : 0; } }
//        public int PendingInstancesCount { get { return Instances != null ? Instances.Count(x => x.Status == InstanceStatuses.Pending) : 0; } }

//        public DetailedRegion()
//        {
//            Instances = new List<InstanceInfo>();

//        }
//    }
//}
