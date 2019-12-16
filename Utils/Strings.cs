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
            return string.Join(",", array.Select(p => p.ToString()).ToArray());
        }

        public static string ArrayToString(this int[] array)
        {
            // Concatenate all the elements into a StringBuilder.
            return string.Join(",", array.Select(p => p.ToString()).ToArray());
        }

        public static IEnumerable<int> StringToEnumerableInt(string input)
        {

            string[] separator = { "\n", "\r\n", ", ", "," };
            return input.Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x));
        }

        public static IEnumerable<string> StringToEnumerableString(string input)
        {

            string[] separator = { "\n", "\r\n", ", ", "," };
            return input.Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(Convert.ToString);
        }

        public static IEnumerable<string> ToEnumerableString(this string input)
        {

            string[] separator = {  "\r\n", ", ", "," ,"\n"};
            return input.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string ConvertStringArrayToString(long[] array)
        {
            return string.Join(",", array.Select(p => p.ToString()).ToArray());
        }

        public static Dictionary<T1, T2> ToDictionary<T1, T2>(this KeyValuePair<T1, T2> kvp)
        {
            var dict = new Dictionary<T1, T2>();
            dict.Add(kvp.Key, kvp.Value);
            return dict;
        }
    }
}
