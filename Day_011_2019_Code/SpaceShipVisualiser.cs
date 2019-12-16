using System.Text;
using SharedCode;

namespace Day_11_2019_Code
{
    public class SpaceShipVisualiser
    {
        private readonly IArea _spaceShip;

        public SpaceShipVisualiser(IArea spaceShip)
        {
            _spaceShip = spaceShip;
        }

        public string Draw()
        {
            var minX = _spaceShip.GetMinX();
            var maxX = _spaceShip.GetMaxX();
            var minY = _spaceShip.GetMinY();
            var maxY = _spaceShip.GetMaxY();

            var displayImage = new StringBuilder();
            for (var y = minY; y <= maxY; y++)
            {
                for (var x = minX; x <= maxX; x++)
                {
                    if (_spaceShip.IsPainted((x, y)))
                    {
                        if (_spaceShip.GetPaintedSquareColour((x, y)) == PaintColour.Black)
                        {
                            displayImage.Append(".");
                        }
                        else if (_spaceShip.GetPaintedSquareColour((x, y)) == PaintColour.White)
                        {
                            displayImage.Append("#");
                        }
                    }
                    else
                    {
                        displayImage.Append(".");
                    }
                }

                displayImage.Append("E");
            }

            return displayImage.ToString();
        }
    }
}