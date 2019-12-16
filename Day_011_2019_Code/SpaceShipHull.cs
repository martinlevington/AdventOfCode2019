using System;
using System.Collections.Generic;
using System.Linq;
using SharedCode;

namespace Day_11_2019_Code
{
    public class SpaceShipHull : IArea
    {
        private readonly Dictionary<(int, int), PaintLayer> _hull = new Dictionary<(int, int), PaintLayer>();

        public void PaintSquare((int, int) coordinates, PaintColour colour)
        {
            if (!_hull.ContainsKey((coordinates.Item1, coordinates.Item2)))
            {
                _hull.Add((coordinates.Item1, coordinates.Item2), new PaintLayer());
            }

            _hull[(coordinates.Item1, coordinates.Item2)].AddLayer(colour);
        }

        public bool IsPainted((int, int) position)
        {
            return _hull.ContainsKey((position.Item1, position.Item2));
        }

        public PaintColour GetPaintedSquareColour((int, int) position)
        {
            return IsPainted(position) ? _hull[(position.Item1, position.Item2)].GetColour() : PaintColour.Black;
        }

        public int GetNumberOfPaintedPanels()
        {
            return _hull.Count;
        }

        public int GetMinX()
        {
            return _hull.Select(x => x.Key.Item1).Min();
        }

        public int GetMaxX()
        {
            return _hull.Select(x => x.Key.Item1).Max();
        }

        public int GetMaxY()
        {
            return _hull.Select(x => x.Key.Item2).Max();
        }

        public int GetMinY()
        {
            return _hull.Select(x => x.Key.Item2).Min();
        }

        public void AddElement((int, int) position, char element)
        {
            throw new NotImplementedException();
        }

        public bool ElementExists((int, int) position)
        {
            throw new NotImplementedException();
        }

        public char GetElement((int, int) position)
        {
            throw new NotImplementedException();
        }
    }
}