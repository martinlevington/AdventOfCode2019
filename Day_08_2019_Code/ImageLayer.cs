using System;
using System.Linq;
using System.Text;

namespace Day_08_2019_Code
{
    public class ImageLayer
    {
        public int ID { get; set; }
        public int[] dataRows { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }

        public ImageLayer(int sizeX, int sizeY, int[] inputData)
        {
            SizeX = sizeX;
            SizeY = sizeY;

            dataRows = inputData;
        }

     

       public override string ToString()
        {
           
            var output = new StringBuilder();

            // ... Loop over bounds.
            for (int i = 0; i <= dataRows.Length-1; i+=SizeX)
            {
                var row = dataRows[i];
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
            return dataRows.Count(x => x == d);
        }

        public int GetPixel(int x, int y)
        {
            return dataRows[(y*SizeX) + x];
        }

    }
}
