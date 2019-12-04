using System;
using Day_04_2019_Code;

namespace Day_04_2019_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var passwordChecker = new NumberOfPasswords();
            var numberOfPasswords = passwordChecker.FindPasswords(168630, 718098);

            Console.WriteLine("Answer: "+numberOfPasswords);

        }
    }
}
