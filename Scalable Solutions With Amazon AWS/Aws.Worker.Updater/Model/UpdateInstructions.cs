namespace Aws.Worker.Updater.Model
{
    public class UpdateInstructions
    {
        public string AwsAccessKey { get; set; }
        public string AwsSecretKey { get; set; }
        public string BucketName { get; set; }
        public string RemotePath { get; set; }
        public string ExePath { get; set; }
        public string ErrorUrl { get; set; }
        public string Folder { get; set; }
        public string TempDir { get; set; }
        public bool IsService { get; set; }
        public int StartDelay { get; set; }
    }
}