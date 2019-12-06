using Day_06_2019_Code;
using System;
using System.Linq;
using Xunit;

namespace Day_06_2019_Tests
{
    public class Part1Tests
    {

        [Fact]
        public void CanCreateTreeWithRootNode()
        {

            // Arrange

            var sut = new Tree("COM");

            // Act
            var result = sut.GetRootNode();

            // Assert
            Assert.IsType<TreeNode>(result);
            Assert.Equal("COM", result.val);
        }


        [Theory]
        [InlineData("COM")]
        [InlineData("G")]
        public void TestDefaultNodeExists(string nodeId)
        {

            // Arrange
            string[] separator = { "\n", "\r\n", ", ", "," };
            var orbits = example.Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(x => x).ToArray();

            var sut = new Tree(orbits);

            // Act
            var result = sut.NodeExists(nodeId);

            // Assert
            Assert.IsType<bool>(result);
            Assert.True(result);
        }

        [Fact]
        public void NodeShouldNotExists()
        {

            // Arrange

            var sut = new Tree(example);

            // Act
            var result = sut.NodeExists("O");

            // Assert
            Assert.IsType<bool>(result);
            Assert.False(result);
        }

        [Fact]
        public void Node_G_FromExampleShouldxists()
        {

            // Arrange
            string[] separator = { "\n", "\r\n", ", ", "," };
            var orbits = example.Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(x => x).ToArray();
            var sut = new Tree(orbits);

            // Act
            var result = sut.NodeExists("G");

            // Assert
            Assert.IsType<bool>(result);
            Assert.True(result);
        }


        [Fact]
        public void CountPaths_Part1_Example()
        {
            // Arrange
            string[] separator = { "\n", "\r\n", ", ", "," };
            var orbits = example.Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(x => x).ToArray();
            var sut = new Tree(orbits);

            // Act
            var result = sut.CountAllPaths();

            // Assert
            Assert.IsType<int>(result);
            Assert.Equal(42, result);
            
        }

        // 295936
        public void CountPaths_Part1_FindAnswer()
        {
            // Arrange
            string[] orbits = System.IO.File.ReadAllLines(@"input.txt");
            var sut = new Tree(example);

            // Act
            var result = sut.CountAllPaths();

            // Assert
            Assert.IsType<int>(result);
            Assert.Equal(295936, result);

        }

        private string example = @"COM)B
B)C
C)D
D)E
E)F
B)G
G)H
D)I
E)J
J)K
K)L";
    }
}
