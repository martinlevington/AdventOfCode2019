using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SharedCode
{
    public class AreaTextVisualiser
    {
        private readonly IAreaSize _area;
        private readonly string _lineEnd = "|";

        public AreaTextVisualiser(IAreaSize area)
        {
            _area = area;
        }

        public char PathChar = '+';
        public ConsoleColor PathColour = ConsoleColor.DarkGreen;

        public string Draw((int,int) pointer, char defaultChar = ' ', char border = ' ')
        {
            var minX = _area.GetMinX();
            var maxX = _area.GetMaxX();
            var minY = _area.GetMinY();
            var maxY = _area.GetMaxY();

       

            var displayImage = new StringBuilder();
            // top Border
            for (var x = minX; x <= maxX+2; x++)
            {
                displayImage.Append(border);
            }
            displayImage.Append(_lineEnd);

            for (var y = maxY; y >= minY; y--)
            {
               
                    displayImage.Append(border);
                
                for (var x = minX; x <= maxX; x++)
                {

                    if (_area.ElementExists((x, y)))
                    {
                        Console.ForegroundColor = _area.GetElement((x, y)) == PathChar ? PathColour : ConsoleColor.White;

                        if (pointer == (x, y))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            displayImage.Append('R');
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            displayImage.Append(_area.GetElement((x, y)));
                        }
                    }
                    else
                    {
                        displayImage.Append(defaultChar);
                    }

                }

              
                    displayImage.Append(border);
                

                displayImage.Append(y);
                displayImage.Append(_lineEnd);

              
            }

            // bottom border
            for (var x = minX; x <= maxX+2; x++)
            {
                displayImage.Append(border);
            }
            displayImage.Append(_lineEnd);

            displayImage.Append(_lineEnd);
            return displayImage.ToString();
        }

        public string GetLineEnd()
        {
            return _lineEnd;
        }
    }
}