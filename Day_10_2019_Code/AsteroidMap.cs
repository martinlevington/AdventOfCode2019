using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_10_2019_Code
{
    public class AsteroidMap
    {
        private readonly Dictionary<(int, int), string> _map;

        private readonly Dictionary<(int, int), int> _vaporisedAsteroids = new Dictionary<(int, int), int>();
        private readonly Dictionary<(int, int), int> _visibleAsteroids;
        private Dictionary<(int, int), double> _baseAsteroidsAngles = new Dictionary<(int, int), double>();
        private Dictionary<(int, int), double> _baseAsteroidsDistances = new Dictionary<(int, int), double>();

        public AsteroidMap(Dictionary<(int, int), string> initialMap)
        {
            _map = initialMap;
            _visibleAsteroids = new Dictionary<(int, int), int>();
        }

        public (int, int) LoggedAsteroid { get; set; }

        public int MapAllVisibleAsteroids()
        {
            foreach (var asteroid in _map)
            {
                var found = 0;
                if (asteroid.Value == "#")
                {
                    var foundAsteroids = (from testAsteroid in _map
                        where testAsteroid.Value == "#" && asteroid.Key != testAsteroid.Key
                        select GetAngle(asteroid.Key, testAsteroid.Key)).ToList();
                    found = foundAsteroids.Distinct().Count();
                }

                _visibleAsteroids.Add((asteroid.Key.Item1, asteroid.Key.Item2), found);
            }

            return _visibleAsteroids.Max(x => x.Value);
        }

        public int GetAsteroidCount()
        {
            return _map.Count(x => x.Value == "#");
        }

        public bool CanShoot()
        {
            return _map.Count(x => x.Value == "#") > 1;
        }

        public void VaporiseAllVisibleAsteroids((int, int) point, int logIndex)
        {
            while (CanShoot())
            {
                VaporiseVisibleAsteroids(point, logIndex);
            }
        }

        public void VaporiseVisibleAsteroids((int, int) point, int logIndex)
        {
            CalculateAnglesToAsteroidsForStation(point);
            CalculateDistancesToAsteroidsForStation(point);

            _baseAsteroidsDistances.Remove(point);
            _baseAsteroidsAngles.Remove(point);

            var currentRound = new Dictionary<(int, int), double>();

            // get a list of angles and the asteroids on that angle
            var basesAtAngle = new Dictionary<double, List<(int, int)>>();
            foreach (var kvp in _baseAsteroidsAngles)
            {
                if (!basesAtAngle.ContainsKey(kvp.Value))
                {
                    var listOfBases = new List<(int, int)> {kvp.Key};
                    basesAtAngle.Add(kvp.Value, listOfBases);
                }
                else
                {
                    basesAtAngle[kvp.Value].Add(kvp.Key);
                }
            }

            var visibleAsteroids =
                basesAtAngle.ToDictionary(kvp => kvp.Key,
                    kvp => kvp.Value.OrderBy(x => GetDistance(point, x)).ToList().First());

            var orderedVisibleAsteroids =
                visibleAsteroids.OrderBy(r => r.Key).Select(or => (or.Key, or.Value)).ToList();

            for (var i = 0; i < orderedVisibleAsteroids.Count(); i++)
            {
                _vaporisedAsteroids.Add(orderedVisibleAsteroids[i].Value, i);
                if (_vaporisedAsteroids.Count == logIndex)
                {
                    LoggedAsteroid = orderedVisibleAsteroids[i].Value;
                }

                _map.Remove(orderedVisibleAsteroids[i].Value);
            }
        }

        private void CalculateAnglesToAsteroidsForStation((int, int) point)
        {
            _baseAsteroidsAngles = new Dictionary<(int, int), double>();
            if (_map[point] != "#")
            {
                return;
            }

            foreach (var testAsteroid in _map.Where(testAsteroid => testAsteroid.Value == "#"))
            {
                _baseAsteroidsAngles[testAsteroid.Key] = GetAngle(point, testAsteroid.Key);
            }
        }

        private void CalculateDistancesToAsteroidsForStation((int, int) point)
        {
            _baseAsteroidsDistances = new Dictionary<(int, int), double>();
            if (_map[point] != "#")
            {
                return;
            }

            foreach (var testAsteroid in _map.Where(testAsteroid => testAsteroid.Value == "#"))
            {
                _baseAsteroidsDistances[testAsteroid.Key] = GetDistance(point, testAsteroid.Key);
            }
        }

        private double GetDistance((int, int) pointA, (int, int) pointB)
        {
            return Math.Pow(pointA.Item1 - pointB.Item1, 2) + Math.Pow(pointA.Item2 - pointB.Item2, 2);
        }

        private static double GetAngle((int, int) pointA, (int, int) pointB)
        {
            double xDiff = pointB.Item1 - pointA.Item1;
            double yDiff = pointB.Item2 - pointA.Item2;

            var angle = Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI;
            angle += 90;
            if (angle < 0)
            {
                angle += 360;
            }

            if (angle >= 360)
            {
                angle -= 360;
            }

            return angle;
        }

        public (int, int) GetBestAsteroidForBase()
        {
            var result = _visibleAsteroids.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            return result;
        }
    }
}