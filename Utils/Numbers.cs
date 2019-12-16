using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public static class Numbers
    {
  
        static long Gcf(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        static long DetermineLcm(long a, long b)
        {
            return (a / Gcf(a, b)) * b;
        }

        public static long DetermineLcm(long a, long b, long c)
        {
            return DetermineLcm(a, DetermineLcm(b, c));
        }

        public static int Lcm(int a, int b)
        {
            return (int) ((a / Gcf(a, b)) * b);
        }
    }
}
