using System;
using System.Collections.Generic;
using System.Linq;
using Day_07_2019_Code;
using Utils;
using Xunit;

namespace Day_07_2019_Tests
{
    public class Part2
    {
        [Theory]
        [InlineData("3,26,1001,26,-4,26,3,27,1002,27,2,27,1,27,26,27,4,27,1001,28,-1,28,1005,28,6,99,0,0,5", "9,8,7,6,5", 139629729)]
                   
        public void TestInitialCodes_Day05(string input, string phases, int expectedResult)
        {
            // Arrange
           
            List<int> inputPhases = Strings.StringToEnumerableInt(phases).ToList();
            var sut = new ThrusterCalculator(input);

            // Act
            var result = sut.ThrustPowerWithFeedBack(inputPhases);

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
