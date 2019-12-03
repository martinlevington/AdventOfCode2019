using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public static class Strings
    {
        public static string ConvertStringArrayToString(string[] array)
        {
            // Concatenate all the elements into a StringBuilder.
            StringBuilder builder = new StringBuilder();
            foreach (string value in array)
            {
                builder.Append(value);
                builder.Append('.');
            }
            return builder.ToString();
        }

        public static string ConvertStringArrayToString(int[] array)
        {
            // Concatenate all the elements into a StringBuilder.
           return  string.Join(",", array.Select(p => p.ToString()).ToArray());
        }

        public static IEnumerable<int> StringToEnumerableInt(string input)
        {

            string[] separator = { ", ", "," };
            return input.Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x));
        }

        public static IEnumerable<string> StringToEnumerableString(string input)
        {

            string[] separator = { ", ", "," };
            return input.Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(Convert.ToString);
        }

    }
}
