using System;
using System.Text;

namespace SharedCode
{
    public class AreaTextVisualiser
    {
        private readonly IAreaSize _area;
        private readonly string _lineEnd = Environment.NewLine;

        private readonly char _pathChar = '+';
        private readonly ConsoleColor _pathColour = ConsoleColor.DarkGreen;

        public AreaTextVisualiser(IAreaSize area)
        {
            _area = area;
        }

        public void Draw((int, int) pointer, char defaultChar = ' ', char border = ' ')
        {
            var minX = _area.GetMinX();
            var maxX = _area.GetMaxX();
            var minY = _area.GetMinY();
            var maxY = _area.GetMaxY();

            var displayImage = new StringBuilder();
            // top Border
            for (var x = minX; x <= maxX + 2; x++)
            {
                Console.Write(border);
            }

            Console.Write(_lineEnd);

            for (var y = maxY; y >= minY; y--)
            {
                Console.Write(border);

                for (var x = minX; x <= maxX; x++)
                {
                    if (_area.ElementExists((x, y)))
                    {
                        Console.ForegroundColor =
                            _area.GetElement((x, y)) == _pathChar ? _pathColour : ConsoleColor.White;

                        if (pointer == (x, y))
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write('R');
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            if (_area.GetElement((x, y)) == '.')
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                            }

                            if (_area.GetElement((x, y)) == 'O')
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }

                            if (_area.GetElement((x, y)) == 'X')
                            {
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                            }

                            if (_area.GetElement((x, y)) == '+')
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                            }

                            Console.Write(_area.GetElement((x, y)));
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    else
                    {
                        Console.Write(defaultChar);
                    }
                }

                Console.Write(border);
                Console.Write(y);
                Console.Write(_lineEnd);
            }

            // bottom border
            for (var x = minX; x <= maxX + 2; x++)
            {
                Console.Write(border);
            }

            Console.Write(_lineEnd);
            Console.Write(_lineEnd);
        }

        public string GetLineEnd()
        {
            return _lineEnd;
        }
    }
}