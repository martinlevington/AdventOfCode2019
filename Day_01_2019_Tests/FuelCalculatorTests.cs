using System;
using Day_01_2019_Code;
using Xunit;

namespace Day_01_2019_Tests
{
    public class FuelCaculatorTests
    {
       

        // A module of mass 14 requires 2 fuel. This fuel requires no further fuel (2 divided by 3 and rounded down is 0, which would call for a negative fuel),
        // so the total fuel required is still just 2.

        // At first, a module of mass 1969 requires 654 fuel.Then, this fuel requires 216 more fuel(654 / 3 - 2). 216 then requires 70 more fuel, which requires 21
        // fuel, which requires 5 fuel, which requires no further fuel.So, the total fuel required for a module of mass 1969 is 654 + 216 + 70 + 21 + 5 = 966.

        // The fuel required by a module of mass 100756 and its fuel is: 33583 + 11192 + 3728 + 1240 + 411 + 135 + 43 + 12 + 2 = 50346.

        [Theory]
        [InlineData(14, 2)]
        [InlineData(1969, 966)]
        [InlineData(100756, 50346)]
        public void FuelCalculatorIncFuel(int weight, int expectedResult)
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
