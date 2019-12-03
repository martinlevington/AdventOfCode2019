using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Day_03_2019_Code
{
    public class IntersectionDetection
    {
        private PathGrid _pathGridA;
        private PathGrid _pathGridB;

        public IntersectionDetection(PathGrid pathgridA, PathGrid pathgridB)
        {
            _pathGridA = pathgridA;
            _pathGridB = pathgridB;
        }

        public IEnumerable<(int, int)> FindIntersections()
        {
            return (from point in _pathGridA.GetAllPoints() where _pathGridB.PointExists(point.Key) select point.Key).ToList();
        }



    }
}
