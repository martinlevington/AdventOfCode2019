using System;
using System.IO;
using Day_14_2019_Code;

namespace Day_14_2019_Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Part 1!");
            var input = File.ReadAllLines(@"input.txt");

            var reader = new EquationReader(input);
            var solver = new EquationSolver(reader.Equations);

            var result = solver.Consume("FUEL", 1);

            Console.WriteLine("Required ORE: " + solver.GetConsumedChemicals("ORE"));

            Console.WriteLine("Part 2!");

            var fuel = solver.CalculateFuelFromOre(1000000000000);
            Console.WriteLine("Fuel From 1 Trillion ORE: " + fuel);
        }
    }
}