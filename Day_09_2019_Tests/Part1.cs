using SharedCode;
using System;
using Xunit;

namespace Day_09_2019_Tests
{
    public class Part1
    {

        [Theory]
        [InlineData("109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99", "109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99")]

        public void TestInitialCodes(string input, string expectedResult)
        {
            // Arrange
            var writer = new OutputBufferQueue();
            var inputBuffer = new InputBuffer();
            var memory = new VirtualMemory(input);
            var sut = new Intcode(memory, writer, inputBuffer);

            // Act
            sut.Process();
            var output = writer.ToString();

            //Assert
            Assert.Equal(expectedResult, output);
        }

        [Theory]
        [InlineData("3,0,4,0,99", 12, "12")]
        public void TestInitialCodes_Day09(string input, int inputValue, string expectedResult)
        {
            // Arrange
            var writer = new OutputBufferQueue();
            var inputBuffer = new InputBuffer();
            inputBuffer.Add(inputValue);
            var memory = new VirtualMemory(input);
            var sut = new Intcode(memory, writer, inputBuffer);

            // Act

            sut.Process();
            var output = writer.ToString();

            //Assert
            Assert.Equal(expectedResult, output); 
        }

        [Theory]
        [InlineData("109,9,21107,666,555,0,204,0,99,-1", 7, "0")]
        [InlineData("109,9,21107,555,666,0,204,0,99,-1", 7, "1")]
        public void TestInitialCodes_Day09_21107(string input, int inputValue, string expectedResult)
        {
            // Arrange
            var writer = new OutputBufferQueue();
            var inputBuffer = new InputBuffer();
            inputBuffer.Add(inputValue);
            var memory = new VirtualMemory(input);
            var sut = new Intcode(memory, writer, inputBuffer);

            // Act

            sut.Process();
            var output = writer.ToString();

            //Assert
            Assert.Equal(expectedResult, output);
        }



        [Theory]
        [InlineData("1102,34915192,34915192,7,4,7,99,0", 16)]
        public void TestInitialCodes_Day09_CheckOutLength(string input, int expectedResult)
        {
            // Arrange
            var writer = new OutputBufferQueue();
            var inputBuffer = new InputBuffer();
  
            var memory = new VirtualMemory(input);
            var sut = new Intcode(memory, writer, inputBuffer);

            // Act

            sut.Process();
            var output = writer.ToString();

            //Assert
            Assert.Equal(expectedResult, output.Length);
        }

        [Theory]
        [InlineData("104,1125899906842624,99", "1125899906842624")]
        public void TestInitialCodes_Day09_CheckOut_WithNoInput(string input, string expectedResult)
        {
            // Arrange
            var writer = new OutputBufferQueue();
            var inputBuffer = new InputBuffer();

            var memory = new VirtualMemory(input);
            var sut = new Intcode(memory, writer, inputBuffer);

            // Act

            sut.Process();
            var output = writer.ToString();

            //Assert
            Assert.Equal(expectedResult, output);
        }

    }
}
