using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils
{
 
    /// <summary>
    /// To use var values = EnumUtil.GetValues<Foos>();
    /// </summary>
    public static class EnumUtil {
        public static IEnumerable<T> GetValues<T>() {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
