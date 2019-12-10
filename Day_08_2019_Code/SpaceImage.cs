using System;
using System.Collections.Generic;
using System.Text;

namespace Day_08_2019_Code
{

    public class SpaceImage
    {
        public int[] dataRows { get; set; }
        private List<ImageLayer> _layers;
        public int SizeX { get; set; }
        public int SizeY { get; set; }


        public SpaceImage(int sizeX, int sizeY, int[] inputData)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            _layers = new List<ImageLayer>();

            dataRows = inputData;
            makeLayers(inputData);
        }


        private void makeLayers(int[] inputData)
        {
            for (int i = 0; i <= inputData.Length - 1; i += SizeY*SizeX)
            {
                var imageData = new int[SizeX * SizeY];
                for (int y = 0; y < SizeY ; y++)
                {
                    for (int x = 0; x < SizeX ; x++)
                    {
                        imageData[(y * SizeX)+x] = inputData[(y*SizeX)+x+i];                      
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
            var count = Int32.MaxValue;
            ImageLayer foundLayer  = null;

            foreach(var layer in _layers)
            {
                var x = layer.GetNumberOfDigits(digit);
                if(x < count)
                {
                    count = x;
                    foundLayer = layer;
                }
            }

            return foundLayer;
        }

        public string DecodeLayers()
        {

            var dispayImage = new StringBuilder();
            for (int y = 0; y < SizeY; y++)
            {
                for (int x = 0; x < SizeX; x++)
                {
                    foreach (var layer in _layers)
                    {
                        var pixel = layer.GetPixel(x, y);
                        // add first pixel which is not transparent
                        if (pixel != 2)
                        {
                            dispayImage.Append(pixel);
                            break;
                        }
                    }
                }
                dispayImage.Append("E");
            }


            return dispayImage.ToString();
        }

    }
}
