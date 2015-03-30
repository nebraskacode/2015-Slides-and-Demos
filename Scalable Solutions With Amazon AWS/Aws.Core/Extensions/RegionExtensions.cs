using System;
using System.Collections.Generic;
using System.Linq;
using Amazon;
using Amazon.EC2.Model;
using Aws.Core.Models;

namespace Aws.Core.Extensions
{
    internal static class RegionExtensions
    {
        public static RegionEndpoint ToAwsRegionEndpoint(this AwsRegionLocations awsRegionLocation)
        {
            switch (awsRegionLocation)
            {
                case AwsRegionLocations.UsEast:
                    return RegionEndpoint.USEast1;
                case AwsRegionLocations.UsWest1:
                    return RegionEndpoint.USWest1;
                case AwsRegionLocations.UsWest2:
                    return RegionEndpoint.USWest2;
                case AwsRegionLocations.EuWest:
                    return RegionEndpoint.EUWest1;
                case AwsRegionLocations.SaEast:
                    return RegionEndpoint.SAEast1;
                case AwsRegionLocations.ApNortheast:
                    return RegionEndpoint.APNortheast1;
                case AwsRegionLocations.ApSoutheast1:
                    return RegionEndpoint.APSoutheast1;
                case AwsRegionLocations.ApSoutheast2:
                    return RegionEndpoint.APSoutheast2;
                default:
                    throw new ArgumentException("Unmapped region type. Add mapping to RegionExtensions class", "awsRegionLocation");
            }
        }
    }
}