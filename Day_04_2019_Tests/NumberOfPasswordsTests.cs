using System;
using Day_04_2019_Code;
using Xunit;

namespace Day_04_2019_Tests
{
    public class NumberOfPasswordsTests
    {
        [Theory]
        [InlineData(111111, 111111, 1)]
        [InlineData(111111, 111112, 2)]
        [InlineData(223450, 223450, 0)]
        [InlineData(123789, 123789, 0)]
        public void Test_IsAccepted(int start, int end, int expectedAnswer)
        {
            // Arrange
            var passwordChecker = new NumberOfPasswords();

            //Act
            var numberOfPasswords = passwordChecker.FindPasswords(start, end);

            //Assert
            Assert.Equal(expectedAnswer, numberOfPasswords);

        }
    }
}
