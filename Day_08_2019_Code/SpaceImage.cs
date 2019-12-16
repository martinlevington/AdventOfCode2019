using System.Collections.Generic;
using System.Text;
using SharedCode;

namespace Day_08_2019_Code
{
    public class SpaceImage
    {
        private readonly List<ImageLayer> _layers;


        public SpaceImage(int sizeX, int sizeY, int[] inputData)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            _layers = new List<ImageLayer>();

            DataRows = inputData;
            MakeLayers(inputData);
        }

        public int[] DataRows { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }


        private void MakeLayers(int[] inputData)
        {
            for (var i = 0; i <= inputData.Length - 1; i += SizeY * SizeX)
            {
                var imageData = new int[SizeX * SizeY];
                for (var y = 0; y < SizeY; y++)
                {
                    for (var x = 0; x < SizeX; x++)
                    {
                        imageData[y * SizeX + x] = inputData[y * SizeX + x + i];
                    }
                }

                _layers.Add(new ImageLayer(SizeX, SizeY, imageData));
            }
        }

        public int GetLayerCount()
        {
            return _layers.Count;
        }

        public ImageLayer GetImageLayerWithFewest(int digit)
        {
            var count = int.MaxValue;
            ImageLayer foundLayer = null;

            foreach (var layer in _layers)
            {
                var x = layer.GetNumberOfDigits(digit);
                if (x >= count)
                {
                    continue;
                }

                count = x;
                foundLayer = layer;
            }

            return foundLayer;
        }
        public string DecodeLayers()
        {
            var displayImage = new StringBuilder();
            for (var y = 0; y < SizeY; y++)
            {
                for (var x = 0; x < SizeX; x++)
                {
                    foreach (var layer in _layers)
                    {
                        var pixel = layer.GetPixel(x, y);
                        if (pixel == 2)
                        {
                            continue;
                        }

                        displayImage.Append(pixel);
                        break;
                    }
                }

                displayImage.Append("E");
            }

            return displayImage.ToString();
        }
    }
}