using System;
using System.IO;
using Day_06_2019_Code;

namespace Day_06_2019_Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var orbits = File.ReadAllLines(@"input.txt");

            var tree = new Tree(orbits);

            var result = tree.CountAllPaths();

            Console.WriteLine("The Root Node Is:" + tree.GetRootNode().Val);

            Console.WriteLine("Part One Result:" + result);

            var hops = tree.HopsToSanta();
            Console.WriteLine("Part Two Hops:" + hops);

            Console.ReadLine();
        }
    }
}