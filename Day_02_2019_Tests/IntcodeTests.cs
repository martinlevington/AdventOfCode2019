using Day_02_2019_Code;
using Xunit;

namespace Day_02_2019_Tests
{
    public class IntcodeTests
    {
        // 1,0,0,0,99 becomes 2,0,0,0,99 (1 + 1 = 2).
        // 2,3,0,3,99 becomes 2,3,0,6,99 (3 * 2 = 6).
        // 2,4,4,5,99,0 becomes 2,4,4,5,99,9801 (99 * 99 = 9801).
        // 1,1,1,4,99,5,6,0,99 becomes 30,1,1,4,2,5,6,0,99.


        [Theory]
        [InlineData("1,0,0,0,99", "2,0,0,0,99")]
        [InlineData("2,3,0,3,99", "2,3,0,6,99")]
        [InlineData("2,4,4,5,99,0", "2,4,4,5,99,9801")]
        [InlineData("1,1,1,4,99,5,6,0,99", "30,1,1,4,2,5,6,0,99")]
        [InlineData("1,9,10,3,2,3,11,0,99,30,40,50", "3500,9,10,70,2,3,11,0,99,30,40,50")]
        public void TestInitialCodes(string input, string expectedResult)
        {
            // Arrange
            var sut = new Intcode(input);

            // Act
            sut.Process();
            var result = sut.Result();

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}