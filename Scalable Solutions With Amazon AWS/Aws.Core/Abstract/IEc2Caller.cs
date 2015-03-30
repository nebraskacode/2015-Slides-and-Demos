using System;
using Aws.Core.Models;

namespace Aws.Core.Abstract
{
    public interface IEc2Caller
    {
        RegionDetails GetRegionData(AwsRegionLocations region);
        void LaunchInstance(AwsRegionLocations region, Action<AwsRegionLocations> instanceLaunched);
        void TerminateInstance(AwsRegionLocations region, Action<AwsRegionLocations> instanceTerminated);
    }
}