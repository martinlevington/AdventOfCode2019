using System;
using System.Collections.Generic;


namespace Day_01_2019_Console
{
    public static class StringExtensionMethods
    {
        public static IEnumerable<string> GetLines(this string str, bool removeEmptyLines = false)
        {
            return str.Split(new[] { "\r\n", "\r", "\n" },
                removeEmptyLines ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None);
        }
    }
}
