using System;
using System.Linq;
using Day_08_2019_Code;

namespace Day_08_2019_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Up!");


            string[] imagedata = System.IO.File.ReadAllLines(@"input.txt");
            var data = imagedata[0];

            var img = new SpaceImage(25, 6, data.Select(x => Convert.ToInt32(x.ToString())).ToArray());

            //Act
            var layer = img.GetImageLayerWithFewest(0);
            var num1s = layer.GetNumberOfDigits(1);
            var num2s = layer.GetNumberOfDigits(2);
            var answer = num1s * num2s;

            Console.WriteLine("Part One Answer:" +answer );

            Console.WriteLine("Part Two Answer:");
            var decodeImg = img.DecodeLayers();
            var decodeImgLines = decodeImg.Split('E');


            foreach(var line in decodeImgLines)
            {
                Console.WriteLine(line);
            }




            Console.ReadLine();

        }
    }
}
