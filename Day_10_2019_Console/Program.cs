using System;
using Day_10_2019_Code;

namespace Day_10_2019_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Up!");
            Console.WriteLine("Part 1");

            var mapData = System.IO.File.ReadAllLines(@"input.txt");

            var mapReader = new MapReader(mapData);
            var map = new AsteroidMap(mapReader.ToDictionary());
          
            var result = map.MapAllVisibleAsteroids();

            Console.WriteLine("Visible Asteroids: "+ result);
            Console.WriteLine("Best Location For Base: "+ map.GetBestAsteroidForBase().Item1 + ","+map.GetBestAsteroidForBase().Item2);

            mapReader = new MapReader(mapData);
            map = new AsteroidMap(mapReader.ToDictionary());
            
            map.MapAllVisibleAsteroids();
            map.VaporiseVisibleAsteroids(( map.GetBestAsteroidForBase().Item1, map.GetBestAsteroidForBase().Item2), 200);
            Console.WriteLine("200th Asteroid: ");
            Console.WriteLine("Answer: "+((map.LoggedAsteroid.Item1*100)+map.LoggedAsteroid.Item2));

            Console.WriteLine("Press Enter to Continue!");
            Console.ReadLine();
        }
    }
}
