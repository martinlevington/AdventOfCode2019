using System.Collections.Generic;
using System.Linq;
using SharedCode;

namespace Day_12_2019_Code
{
    public class NBody
    {
        private readonly List<Moon> _moons = new List<Moon>();

         public NBody(List<Moon> moons)
        {
            _moons = moons;
        }

        public void Step()
        {
            ApplyGravity();
            ApplyVelocity();
        }

        public Moon GetMoon(int index)
        {
            return _moons[index];
        }

        // Once all gravity has been applied, apply velocity: simply add the velocity of each moon to its own position.
        // For example, if Europa has a position of x=1, y=2, z=3 and a velocity of x=-2, y=0,z=3, then its new
        // position would be x=-1, y=2, z=6. This process does not modify the velocity of any moon.
        private void ApplyVelocity()
        {
            foreach (var moon in _moons)
            {
                moon.X = moon.X + moon.VelocityX;
                moon.Y = moon.Y + moon.VelocityY;
                moon.Z = moon.Z + moon.VelocityZ;
            }
        }

        // To apply gravity, consider every pair of moons. On each axis (x, y, and z), the velocity of each moon changes
        // by exactly +1 or -1 to pull the moons together. For example, if Ganymede has an x position of 3, and Callisto
        // has a x position of 5, then Ganymede's x velocity changes by +1 (because 5 > 3) and Callisto's x velocity
        // changes by -1 (because 3 < 5). However, if the positions on a given axis are the same, the velocity on that
        // axis does not change for that pair of moons.
        private void ApplyGravity()
        {
            var combinations = Enumerable.Range(0, _moons.Count()).Select(x => x).DifferentCombinations(2).ToArray();

            foreach (var combination in combinations)
            {
                var el = combination.ToArray();
                if (_moons[el[0]].X < _moons[el[1]].X)
                {
                    _moons[el[0]].VelocityX++;
                    _moons[el[1]].VelocityX--;
                }
                else if (_moons[el[0]].X > _moons[el[1]].X)
                {
                    _moons[el[0]].VelocityX--;
                    _moons[el[1]].VelocityX++;
                }
            }

            foreach (var combination in combinations)
            {
                var el = combination.ToArray();
                if (_moons[el[0]].Y < _moons[el[1]].Y)
                {
                    _moons[el[0]].VelocityY++;
                    _moons[el[1]].VelocityY--;
                }
                else if (_moons[el[0]].Y > _moons[el[1]].Y)
                {
                    _moons[el[0]].VelocityY--;
                    _moons[el[1]].VelocityY++;
                }
            }

            foreach (var combination in combinations)
            {
                var el = combination.ToArray();
                if (_moons[el[0]].Z < _moons[el[1]].Z)
                {
                    _moons[el[0]].VelocityZ++;
                    _moons[el[1]].VelocityZ--;
                }
                else if (_moons[el[0]].Z > _moons[el[1]].Z)
                {
                    _moons[el[0]].VelocityZ--;
                    _moons[el[1]].VelocityZ++;
                }
            }
        }
        public int GetTotalEnergy()
        {
            return _moons.Sum(moon => moon.GetTotalEnergy());
        }
    }
}