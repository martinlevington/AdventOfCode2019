using System;
using System.Linq;
using Day_08_2019_Code;
using Xunit;

namespace Day_08_2019_Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Example1_Makes2Layers()
        {
            // Arrange
            var data = "123456789012";
            var img = new SpaceImage(3,2,data.Select(x => Convert.ToInt32(x.ToString())).ToArray());

            //Act
            var result = img.GetLayerCount();

            //Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void Example1_OneDigitsMultiNum2Digits()
        {
            // Arrange
            var data = "123456789012";
            var img = new SpaceImage(3, 2, data.Select(x => Convert.ToInt32(x.ToString())).ToArray());

            //Act
            var layer = img.GetImageLayerWithFewest(1);
            var num1s = layer.GetNumberOfDigits(1);
            var num2s = layer.GetNumberOfDigits(2);


            //Assert
            Assert.Equal(1, num1s*num2s);
        }
    }
}
