using System;
using System.Collections.Generic;
using System.Linq;

namespace DiskraChecker
{
    public static class EnumUtil {
        public static IEnumerable<T> GetEnumValues<T>() where T:struct {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}