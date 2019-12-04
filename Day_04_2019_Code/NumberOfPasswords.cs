using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace Day_04_2019_Code
{
    public class NumberOfPasswords
    {
        private readonly List<string> searchItems = new List<string>()
        {
            "11",
            "22",
            "33",
            "44",
            "55",
            "66",
            "77",
            "88",
            "99"
        };

        public int FindPasswords(int start, int end)
        {
            var result = 0;

            for (var i = start; i <= end; i++)
            {
                var passwordToCheck = i.ToString();

                if (passwordToCheck.Length == 6
                    && searchItems.Any(x => passwordToCheck.Contains(x))
                    && IsAscending(passwordToCheck)
                )
                {
                    result++;
                }
                
            }


            return result;

        }

        public static bool IsAscending(string x)
        {
            if (x.Length == 1)
            {
                return true;
            }

            var last = Convert.ToInt32(x.Last().ToString());
            var prev = Convert.ToInt32(x[x.Length - 2].ToString());

            return last >= prev  && IsAscending(x.Substring(0, x.Length - 1));
        }
    }
}
