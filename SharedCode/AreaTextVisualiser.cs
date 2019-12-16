using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace SharedCode
{
    public class AreaTextVisualiser
    {
        private readonly IAreaSize _area;
        private string _lineEnd = "|";

        public AreaTextVisualiser(IAreaSize area)
        {
            _area = area;
          
            
        }

        public string Draw()
        {
            var minX = _area.GetMinX();
            var maxX = _area.GetMaxX();
            var minY = _area.GetMinY();
            var maxY = _area.GetMaxY();

            var displayImage = new StringBuilder();
            for (var y = maxY; y > minY; y--)
            {
                for (var x = minX; x <= maxX; x++)
                {
                    if (_area.ElementExists((x, y)))
                    {
                        displayImage.Append(_area.GetElement((x,y)));
                    }
                    else
                    {
                        displayImage.Append(" ");
                    }

                    //if (x == maxX ) displayImage.Append(x);
                }
                 displayImage.Append(y);
                displayImage.Append(_lineEnd);
            }

            return displayImage.ToString();

        }

        public string GetLineEnd()
        {
            return _lineEnd;
        }

      


    }
}
