using System.Collections.Generic;
using System.Linq;
using SharedCode;

namespace Day_11_2019_Code
{
    public class SpaceShipHull : IArea
    {
        private readonly Dictionary<(int, int), PaintLayer> _hull = new Dictionary<(int, int), PaintLayer>();

        public void PaintSquare((int , int) cordinates, PaintColour colour)
        {
            if (!_hull.ContainsKey((cordinates.Item1,cordinates.Item2))) _hull.Add((cordinates.Item1,cordinates.Item2), new PaintLayer());

            _hull[(cordinates.Item1, cordinates.Item2)].AddLayer(colour);
        }

        public bool IsPainted((int,int) position)
        {
            return _hull.ContainsKey((position.Item1, position.Item2));
        }

        public PaintColour GetPaintedSquareColour((int,int) position)
        {
            if (IsPainted(position))
            {
                return _hull[(position.Item1, position.Item2)].GetColour();
            }

            return PaintColour.Black;
        }

        public int  GetNumberOfPaintedPanels()
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
            throw new System.NotImplementedException();
        }

        public bool ElementExists((int, int) position)
        {
            throw new System.NotImplementedException();
        }

        public char GetElement((int, int) position)
        {
            throw new System.NotImplementedException();
        }
    }
}