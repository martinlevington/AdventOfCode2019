using Day_04_2019_Code;
using Xunit;

namespace Day_04_2019_Tests
{
    public class NumberOfPasswordsTests
    {
        [Theory]
        [InlineData(111111, 111111, 0)]
        [InlineData(111111, 111112, 0)]
        [InlineData(111111, 111122, 1)]
        [InlineData(223450, 223450, 0)]
        [InlineData(123789, 123789, 0)]
        [InlineData(112233, 112233, 1)]
        [InlineData(123444, 123444, 0)]
        [InlineData(111122, 111122, 1)]
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