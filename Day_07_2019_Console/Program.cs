using System;
using System.Collections.Generic;
using System.Linq;
using Day_07_2019_Code;

namespace Day_07_2019_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Up!");

            string[] state = System.IO.File.ReadAllLines(@"input.txt");



            var combinations = GetPermutations(new[] { 0, 1, 2, 3, 4 }, 5).ToList();

    

            long maxOutput = 0;
            foreach (var combination in combinations)
            {
                var thrustCalc = new ThrusterCalculator(state[0]);
                var output = thrustCalc.ThrustPower(combination.ToList());
                if (output > maxOutput)
                {
                    maxOutput = output;
                }
            }

            Console.WriteLine("Part One Result:" + maxOutput);


            var combinationsPhase2 = GetPermutations(new[] { 5, 6, 7, 8, 9 }, 5).ToList();
           

            long maxOutputPhase2 = 0;
            foreach (var combination in combinationsPhase2)
            {
                var thrustCalcPhase2 = new ThrusterCalculator(state[0]);
                var output = thrustCalcPhase2.ThrustPowerWithFeedBack(combination.ToList());
                if (output > maxOutputPhase2)
                {
                    maxOutputPhase2 = output;
                }
            }

            Console.WriteLine("Part Two Result:" + maxOutputPhase2);

            Console.WriteLine("Press Enter to Continue!");
            Console.ReadLine();
        }


        static IEnumerable<IEnumerable<T>>
    GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });
            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(o => !t.Contains(o)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

    }




}
