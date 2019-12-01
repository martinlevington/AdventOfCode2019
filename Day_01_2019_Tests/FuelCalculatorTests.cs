using System;
using Day_01_2019_Code;
using Xunit;

namespace Day_01_2019_Tests
{
    public class FuelCaculatorTests
    {
        public FuelCaculatorTests()
        {

        }


        //  For a mass of 12, divide by 3 and round down to get 4, then subtract 2 to get 2.
        //  For a mass of 14, dividing by 3 and rounding down still yields 4, so the fuel required is also 2.
        //  For a mass of 1969, the fuel required is 654.
        //  For a mass of 100756, the fuel required is 33583.

 
        [Theory]
        [InlineData(12, 2)]
        [InlineData(14, 2)]
        [InlineData(100756, 33583)]
        public void InitalExamples(int weight, int expectedResult)
        {
            // Arrange
            var sut = new FuelCalculator();

            // Act
            var result = sut.RequiredFuel(weight);

            //Assert
            Assert.Equal(expectedResult, result);

        }
    }
}
