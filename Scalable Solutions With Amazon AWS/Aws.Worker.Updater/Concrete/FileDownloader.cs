using System;
using System.IO;
using Aws.Core.AwsCallers;
using Aws.Core.Models;

namespace Aws.Worker.Updater.Concrete
{
    public class FileDownloader
    {
        private readonly S3Caller s3Caller;
        private readonly string bucketName;

        public FileDownloader(S3Caller s3Caller, string bucketName)
        {
            this.s3Caller = s3Caller;
            this.bucketName = bucketName;
        }

        public bool DownloadFile(string srcFilename, string destinationFullPath)
        {
            var data = s3Caller.DownloadData(bucketName, srcFilename, AwsRegionLocations.UsEast);
            if (File.Exists(destinationFullPath))
            {
                File.Delete(destinationFullPath);
            }
            File.WriteAllBytes(destinationFullPath, data);
            return true;
        }
    }
}