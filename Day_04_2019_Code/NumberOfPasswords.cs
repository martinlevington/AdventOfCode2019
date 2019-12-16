using System;
using System.Linq;

namespace Day_04_2019_Code
{
    public class NumberOfPasswords
    {
        public int FindPasswords(int start, int end)
        {
            var result = 0;

            for (var i = start; i <= end; i++)
            {
                var passwordToCheck = i.ToString();

                if (passwordToCheck.Length == 6
                    && passwordToCheck.Select(c => c).GroupBy(x => x).Count(y => y.Count() == 2) >= 1
                    && IsAscending(passwordToCheck)
                )
                {
                    result++;
                }
            }


            return result;
        }

        private static bool IsAscending(string x)
        {
            if (x.Length == 1)
            {
                return true;
            }

            var last = Convert.ToInt32(x.Last().ToString());
            var prev = Convert.ToInt32(x[x.Length - 2].ToString());

            return last >= prev && IsAscending(x.Substring(0, x.Length - 1));
        }
    }
}