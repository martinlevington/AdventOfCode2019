using System;
using System.Collections.Generic;
using Day_12_2019_Code;
using Utils;

namespace Day_12_2019_Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // puzzle input
            // <x=0, y=6, z=1>
            // <x=4, y=4, z=19>
            // <x=-11, y=1, z=8>
            // <x=2, y=19, z=15>

            var moons = new List<Moon>
            {
                new Moon(0, 6, 1),
                new Moon(4, 4, 19),
                new Moon(-11, 1, 8),
                new Moon(2, 19, 15)
            };
            var sut = new NBody(moons);
            var currentStep = 0;
            var numberOfSteps = 1000;

            while (currentStep < numberOfSteps)
            {
                sut.Step();
                currentStep++;
            }

            Console.WriteLine("For 1000 Steps: " + sut.GetTotalEnergy());
            Console.WriteLine("Total Energy: " + sut.GetTotalEnergy());

            Console.WriteLine("Finding  Steps to Reach Previous State: ");


            // X
            var moonsX = new List<Moon>
            {
                new Moon(0, 6, 1),
                new Moon(4, 4, 19),
                new Moon(-11, 1, 8),
                new Moon(2, 19, 15)
            };
            sut = new NBody(moonsX);
            var xRotations = 0;
            do
            {
                sut.Step();
                xRotations++;
            } while (!(sut.GetMoon(0).X == 0
                       && sut.GetMoon(1).X == 4
                       && sut.GetMoon(2).X == -11
                       && sut.GetMoon(3).X == 2
                       && sut.GetMoon(0).VelocityX == 0
                       && sut.GetMoon(1).VelocityX == 0
                       && sut.GetMoon(2).VelocityX == 0
                       && sut.GetMoon(3).VelocityX == 0
                ));

            Console.WriteLine("X Moons: " + sut.GetMoon(0).X + " "
                              + sut.GetMoon(1).X + " "
                              + sut.GetMoon(2).X + " "
                              + sut.GetMoon(3).X);

            // Y
            var moonsY = new List<Moon>
            {
                new Moon(0, 6, 1),
                new Moon(4, 4, 19),
                new Moon(-11, 1, 8),
                new Moon(2, 19, 15)
            };
            sut = new NBody(moonsY);

            var yRotations = 0;
            do
            {
                sut.Step();
                yRotations++;
            } while (!(sut.GetMoon(0).Y == 6
                       && sut.GetMoon(1).Y == 4
                       && sut.GetMoon(2).Y == 1
                       && sut.GetMoon(3).Y == 19
                       && sut.GetMoon(0).VelocityY == 0
                       && sut.GetMoon(1).VelocityY == 0
                       && sut.GetMoon(2).VelocityY == 0
                       && sut.GetMoon(3).VelocityY == 0
                ));

            Console.WriteLine("Y Moons: " + sut.GetMoon(0).Y + " "
                              + sut.GetMoon(1).Y + " "
                              + sut.GetMoon(2).Y + " "
                              + sut.GetMoon(3).Y);

            // z
            var moonsZ = new List<Moon>
            {
                new Moon(0, 6, 1),
                new Moon(4, 4, 19),
                new Moon(-11, 1, 8),
                new Moon(2, 19, 15)
            };
            sut = new NBody(moonsZ);

            var zRotations = 0;
            do
            {
                sut.Step();
                zRotations++;
            } while (!(sut.GetMoon(0).Z == 1
                       && sut.GetMoon(1).Z == 19
                       && sut.GetMoon(2).Z == 8
                       && sut.GetMoon(3).Z == 15
                       && sut.GetMoon(0).VelocityZ == 0
                       && sut.GetMoon(1).VelocityZ == 0
                       && sut.GetMoon(2).VelocityZ == 0
                       && sut.GetMoon(3).VelocityZ == 0
                ));

            Console.WriteLine("Z Moons: " + sut.GetMoon(0).Z + " "
                              + sut.GetMoon(1).Z + " "
                              + sut.GetMoon(2).Z + " "
                              + sut.GetMoon(3).Z);


            Console.WriteLine("Rotations: X:" + xRotations + " Y:" + yRotations + " Z:" + zRotations);
            var lcm = Numbers.DetermineLcm(xRotations, yRotations, zRotations);
            Console.WriteLine("Lowest Common Multiple: " + lcm);
        }
    }
}