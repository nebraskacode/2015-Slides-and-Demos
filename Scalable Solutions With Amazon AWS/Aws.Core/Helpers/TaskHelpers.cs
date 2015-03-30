using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Aws.Core.Helpers
{
    public static class TaskHelpers
    {
        public static void HandleTimeoutGracefully(this Task<HttpResponseMessage> task, Action a)
        {
            try
            {
                a();
            }
            catch (AggregateException ex)
            {
                // Catching the timeout
                if (!(ex.InnerException is TaskCanceledException))
                {
                    throw;
                }
            }
        }
    }
}