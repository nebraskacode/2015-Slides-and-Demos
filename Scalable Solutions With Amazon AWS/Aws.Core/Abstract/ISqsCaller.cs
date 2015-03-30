using System.Collections.Generic;
using Aws.Core.Models;

namespace Aws.Core.Abstract
{
    public interface ISqsCaller
    {
        void Enqueue(string message);
        IEnumerable<SqsMessage> GetMessages();
        void DeleteMessage(string receiptHandle);
    }
}