using System;
using System.Linq;
using System.Text;

namespace SharedCode
{
    public class ImageLayer
    {
        public int Id { get; set; }
        public int[] DataRows { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }

        public ImageLayer(int sizeX, int sizeY, int[] inputData)
        {
            SizeX = sizeX;
            SizeY = sizeY;

            DataRows = inputData;
        }

     

       public override string ToString()
        {
           
            var output = new StringBuilder();

            // ... Loop over bounds.
            for (int i = 0; i <= DataRows.Length-1; i+=SizeX)
            {
                var row = DataRows[i];
                for (int x = 0; x < SizeX; x++)
                {
                    output.Append(x);
                }
                output.Append(Environment.NewLine);
            }

            return output.ToString();
        }

        public int GetNumberOfDigits(int d)
        {
            return DataRows.Count(x => x == d);
        }

        public int GetPixel(int x, int y)
        {
            return DataRows[(y*SizeX) + x];
        }

    }
}
