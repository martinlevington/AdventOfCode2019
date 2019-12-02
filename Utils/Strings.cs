using System;
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

    }
}
