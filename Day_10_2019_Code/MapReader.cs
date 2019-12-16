using System.Collections.Generic;
using Utils;

namespace Day_10_2019_Code
{
    public class MapReader
    {
        private readonly Dictionary<(int, int), string> _map = new Dictionary<(int, int), string>();

        public MapReader(string input)
        {
            var lines = input.ToEnumerableString();
            var y = 0;
            foreach (var line in lines)
            {
                var x = 0;
                foreach (var chr in line)
                {
                    _map.Add((x, y), chr.ToString());
                    x++;
                }

                y++;
            }
        }

        public MapReader(string[] lines)
        {
            var y = 0;
            foreach (var line in lines)
            {
                var x = 0;
                foreach (var chr in line)
                {
                    _map.Add((x, y), chr.ToString());
                    x++;
                }

                y++;
            }
        }

        public Dictionary<(int, int), string> ToDictionary()
        {
            return _map;
        }
    }
}