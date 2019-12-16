using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedCode
{
    public class Area : IAreaSize
    {
        private readonly Dictionary<(int, int), char> _area = new Dictionary<(int, int), char>();

        public int GetMinX()
        {
            try
            {
                return _area.Select(x => x.Key.Item1).Min();
            }
            catch (System.InvalidOperationException e)
            {
                return 0;
            }
          
        }

        public int GetMaxX()
        {
            
            try
            {
                return _area.Select(x => x.Key.Item1).Max();
            }
            catch (System.InvalidOperationException e)
            {
                return 0;
            }
        }

        public int GetMaxY()
        {
            
            try
            {
                return _area.Select(x => x.Key.Item2).Max();
            }
            catch (System.InvalidOperationException e)
            {
                return 0;
            }
        }

        public int GetMinY()
        {
          
            try
            {
                return _area.Select(x => x.Key.Item2).Min();
            }
            catch (System.InvalidOperationException e)
            {
                return 0;
            }
        }

        public void AddElement((int,int) position, char element)
        {
            if (_area.ContainsKey(position))
            {
                _area[position] = element;
                return;
            }

            _area.Add(position, element);
        }

        public bool  ElementExists((int, int) position)
        {
            return _area.ContainsKey(position);
        }

        public char GetElement((int, int) position)
        {
            return _area[position];
        }



    }
}
