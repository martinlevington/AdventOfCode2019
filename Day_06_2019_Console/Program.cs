using Day_06_2019_Code;
using System;

namespace Day_06_2019_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string[] orbits = System.IO.File.ReadAllLines(@"input.txt");

            var tree = new Tree(orbits);

            var result = tree.CountAllPaths();

            Console.WriteLine("The Root Node Is:" + tree.GetRootNode().val);

            Console.WriteLine("Part One Result:" + result);

            var hops = tree.HopsToSanta();
            Console.WriteLine("Part Two Hops:" + hops);

            Console.ReadLine();
        }
    }
}
