namespace Aws.Core.Models
{
    public class SqsMessage
    {
        public string Message { get; set; }
        public string ReceiptHandle { get; set; }
    }
}