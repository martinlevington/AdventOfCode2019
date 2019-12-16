using System;
using System.Linq;
using Day_08_2019_Code;
using Xunit;

namespace Day_08_2019_Tests
{
    public class Part2
    {
        [Fact]
        public void Example1_Makes2Layers()
        {
            // Arrange
            var data = "0222112222120000";
            var img = new SpaceImage(2, 2, data.Select(x => Convert.ToInt32(x.ToString())).ToArray());
            var expectedResult = @"01E10E";

            //Act
            var result = img.GetLayerCount();
            var decodeImg = img.DecodeLayers();
            //var decodeImgLines = decodeImg.Split('\n');


            //foreach (var line in decodeImgLines)
            //{
            //    Console.WriteLine(line);
            //}


            //Assert
            Assert.Equal(expectedResult, decodeImg);
        }
    }
}
