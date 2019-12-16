using System.Collections.Generic;

namespace Day_03_2019_Code
{
    public class IntersectionDetection
    {
        private readonly PathGrid _pathGridA;
        private readonly PathGrid _pathGridB;

        public IntersectionDetection(PathGrid pathgridA, PathGrid pathgridB)
        {
            _pathGridA = pathgridA;
            _pathGridB = pathgridB;
        }

        public IEnumerable<(int, int)> FindIntersections()
        {
            var results = new List<(int, int)>();

            foreach (var point in _pathGridA.GetAllPoints())
            {
                if (_pathGridB.PointExists(point.Key))
                {
                    results.Add(point.Key);
                }
            }

            return results;
        }
    }
}