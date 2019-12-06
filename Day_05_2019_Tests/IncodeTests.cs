using Day_05_2019_Code;
using Xunit;

namespace Day_05_2019_Tests
{
    public class IncodeTests
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
            sut.Process(0);
            var result = sut.Result();

            //Assert
            Assert.Equal(expectedResult, result);
        }


        [Theory]
        [InlineData("3,0,4,0,99", 12,"12")]
        public void TestInitialCodes_Day05(string input, int inputValue, string expectedResult)
        {
            // Arrange
            var sut = new Intcode(input);

            // Act
            sut.Process(inputValue);
            var output = sut.Output();

            //Assert
            Assert.Equal(expectedResult, output);
        }

        [Theory]
        [InlineData("1002,4,3,4,33", 12, "")]
        public void TestInitialCodes_Day05_LongInstruction(string input, int inputValue, string expectedResult)
        {
            // Arrange
            var sut = new Intcode(input);

            // Act
            sut.Process(inputValue);
            var output = sut.Output();

            //Assert
            Assert.Equal(expectedResult, output);
        }

        [Theory]
        [InlineData("3,9,8,9,10,9,4,9,99,-1,8", 8, "1")]
        [InlineData("3,3,1108,-1,8,3,4,3,99", 8, "1")]
        public void TestInitialCodes_Day05_EqualToEight(string input, int inputValue, string expectedResult)
        {
            // Arrange
            var sut = new Intcode(input);

            // Act
            sut.Process(inputValue);
            var output = sut.Output();

            //Assert
            Assert.Equal(expectedResult, output);
        }

        [Theory]
        [InlineData("3,9,7,9,10,9,4,9,99,-1,8", 8, "0")]
        [InlineData("3,3,1107,-1,8,3,4,3,99", 8, "0")]
        public void TestInitialCodes_Day05_LessThanEight(string input, int inputValue, string expectedResult)
        {
            // Arrange
            var sut = new Intcode(input);

            // Act
            sut.Process(inputValue);
            var output = sut.Output();

            //Assert
            Assert.Equal(expectedResult, output);
        }


        [Theory]
        [InlineData("3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9", 0, "0")]
        [InlineData("3,12,6,12,15,1,13,14,13,4,13,99,-1,0,1,9", 3, "1")]
        [InlineData("3,3,1105,-1,9,1101,0,0,12,4,12,99,1", 0, "0")]
        [InlineData("3,3,1105,-1,9,1101,0,0,12,4,12,99,1", 3, "1")]
        public void TestInitialCodes_Day05_JumpTests(string input, int inputValue, string expectedResult)
        {
            // Arrange
            var sut = new Intcode(input);

            // Act
            sut.Process(inputValue);
            var output = sut.Output();

            //Assert
            Assert.Equal(expectedResult, output);
        }
        [Theory]
        [InlineData("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99", 0, "999")]
        [InlineData("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99", 8, "1000")]
        [InlineData("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99", 10, "1001")]
        public void TestInitialCodes_Day05_LargerExample(string input, int inputValue, string expectedResult)
        {
            // Arrange
            var sut = new Intcode(input);

            // Act
            sut.Process(inputValue);
            var output = sut.Output();

            //Assert
            Assert.Equal(expectedResult, output);
        }


    }
}