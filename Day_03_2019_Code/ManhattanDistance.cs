using System;
using System.Collections.Generic;

namespace Day_03_2019_Code
{
    public class ManhattanDistance
    {
        private int shortestDistance;

        // Return the sum of distance of one axis. 
        public int CalculateDistance((int, int) pointA, (int, int) pointB)
        {
            var xd = pointA.Item1 - pointB.Item1;
            var yd = pointA.Item2 - pointB.Item2;

            return Math.Abs(xd) + Math.Abs(yd);
        }

        public int CalculateShortestFromOrigin(IEnumerable<(int, int)> points)
        {
            shortestDistance = Int32.MaxValue;

            foreach (var point in points)
            {
                var dist = CalculateDistance((0, 0), (point.Item1, point.Item2));
                if (shortestDistance > dist)
                {
                    shortestDistance = dist;
                }
            }

            return shortestDistance;

        }

    }
}
