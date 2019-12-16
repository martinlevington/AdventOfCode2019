using System;
using System.Collections.Generic;
using Day_12_2019_Code;
using Utils;
using Xunit;

namespace Day_12_2019_Tests
{
    public class Part2
    {
        //<x=-8, y=-10, z=0>
        //<x=5, y=5, z=10>
        //<x=2, y=-7, z=3>
        //<x=9, y=-8, z=-3>

        private readonly List<Moon> _moonsPartX = new List<Moon>
        {
            new Moon(-8, -10, 0),
            new Moon(5, 5, 10),
            new Moon(2, -7, 3),
            new Moon(9, -8, -3)
        };

        private readonly List<Moon> _moonsPartY = new List<Moon>
        {
            new Moon(-8, -10, 0),
            new Moon(5, 5, 10),
            new Moon(2, -7, 3),
            new Moon(9, -8, -3)
        };

        private readonly List<Moon> _moonsPartZ = new List<Moon>
        {
            new Moon(-8, -10, 0),
            new Moon(5, 5, 10),
            new Moon(2, -7, 3),
            new Moon(9, -8, -3)
        };

        [Fact]
        public void Part2_Calc()
        {
            // X
            var sut = new NBody(_moonsPartX);
            var xRotations = 0;
            do
            {
                sut.Step();
                xRotations++;
            } while (!(sut.GetMoon(0).X == -8
                       && sut.GetMoon(1).X == 5
                       && sut.GetMoon(2).X == 2
                       && sut.GetMoon(3).X == 9
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

            sut = new NBody(_moonsPartY);

            var yRotations = 0;
            do
            {
                sut.Step();
                yRotations++;
            } while (!(sut.GetMoon(0).Y == -10
                       && sut.GetMoon(1).Y == 5
                       && sut.GetMoon(2).Y == -7
                       && sut.GetMoon(3).Y == -8
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

            sut = new NBody(_moonsPartZ);

            var zRotations = 0;
            do
            {
                sut.Step();
                zRotations++;
            } while (!(sut.GetMoon(0).Z == 0
                       && sut.GetMoon(1).Z == 10
                       && sut.GetMoon(2).Z == 3
                       && sut.GetMoon(3).Z == -3
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

            // Assert
            Assert.Equal(4686774924, lcm);
        }
    }
}