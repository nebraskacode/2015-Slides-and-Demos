using System;
using System.Collections.Generic;
using System.Linq;
using Aws.Core.Models;

namespace Aws.Core.Helpers
{
    public static class EnumHelpers
    {
        public static IEnumerable<T> GetAllValues<T>()
        {
            return (T[])Enum.GetValues(typeof(T));
        }
    }
}