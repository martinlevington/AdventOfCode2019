using System;
using System.IO;
using System.Linq;
using Day_08_2019_Code;

namespace Day_08_2019_Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Starting Up!");


            var imagedata = File.ReadAllLines(@"input.txt");
            var data = imagedata[0];

            var img = new SpaceImage(25, 6, data.Select(x => Convert.ToInt32(x.ToString())).ToArray());

            var layer = img.GetImageLayerWithFewest(0);
            var num1S = layer.GetNumberOfDigits(1);
            var num2S = layer.GetNumberOfDigits(2);
            var answer = num1S * num2S;

            Console.WriteLine("Part One Answer:" + answer);

            Console.WriteLine("Part Two Answer:");
            var decodeImg = img.DecodeLayers();
            var decodeImgLines = decodeImg.Split('E');


            foreach (var line in decodeImgLines)
            {
                Console.WriteLine(line);
            }


            Console.ReadLine();
        }
    }
}