using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Aws.Core.Credentials;
using Aws.Core.Helpers;
using Aws.Core.Models;

namespace Aws.Core.WorkerCallers
{
    public class WorkerCaller
    {
        private readonly ICredentialsRetriever credentialsRetriever;
        private readonly string s3Bucket;
        private readonly HttpClient client = new HttpClient() { Timeout = TimeSpan.FromSeconds(2) };

        public WorkerCaller(ICredentialsRetriever credentialsRetriever, string s3Bucket)
        {
            this.credentialsRetriever = credentialsRetriever;
            this.s3Bucket = s3Bucket;
        }

        public void RefreshWorkerInfo(InstanceInfo instanceInfo)
        {
            instanceInfo.WorkerInfo = new WorkerInfo() { WorkerOnline = false };
            if (instanceInfo.IpAddress != null)
            {
                var response = client.GetAsync(string.Format("http://{0}:9999/api/Instrumentation/Version", instanceInfo.IpAddress));
                response.HandleTimeoutGracefully(() =>
                {
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        instanceInfo.WorkerInfo.WorkerOnline = true;
                        instanceInfo.WorkerInfo.WorkerVersion = int.Parse(result.Content.ReadAsStringAsync().Result);
                    }
                });
            }
        }

        public bool UpdateWorker(InstanceInfo instanceInfo, string filePath)
        {
            bool success = false;
            var credentials = credentialsRetriever.GetCredentials().GetCredentials();
            var url = string.Format(
                    "http://{0}:9999/api/Instrumentation/Update?accessKey={1}&secretKey={2}&s3bucket={3}&s3path={4}",
                    instanceInfo.IpAddress,
                    credentials.AccessKey,
                    HttpUtility.UrlEncode(credentials.SecretKey),
                    s3Bucket,
                    filePath
                    );

            var response = client.PostAsync(url, new StringContent(""));
            response.HandleTimeoutGracefully(() =>
            {
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    success = true;
                }
            });

            return success;
        }
    }
}