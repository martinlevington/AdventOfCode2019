using System.Linq;
using Day_07_2019_Code;
using Utils;
using Xunit;

namespace Day_07_2019_Tests
{
    public class Part1Tests
    {
        [Theory]
        [InlineData("3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0", "4,3,2,1,0", 43210)]
        public void TestInitialCodes_Day07(string input, string phases, int expectedResult)
        {
            // Arrange
            var sut = new ThrusterCalculator(input);
            var inputPhases = Strings.StringToEnumerableInt(phases).ToList();

            // Act
            var result = sut.ThrustPower(inputPhases);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0", "4,3,2,1,0", 43210)]
        public void TestInitialCodes_Day07_B(string input, string phases, int expectedResult)
        {
            // Arrange
            var sut = new ThrusterCalculator(input);
            var inputPhases = Strings.StringToEnumerableInt(phases).ToList();

            // Act
            var result = sut.ThrustPowerWithFeedBack(inputPhases);

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}