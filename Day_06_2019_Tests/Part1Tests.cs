using System;
using System.IO;
using System.Linq;
using Day_06_2019_Code;
using Xunit;

namespace Day_06_2019_Tests
{
    public class Part1Tests
    {
        [Theory]
        [InlineData("COM")]
        [InlineData("G")]
        public void TestDefaultNodeExists(string nodeId)
        {
            // Arrange
            string[] separator = {"\n", "\r\n", ", ", ","};
            var orbits = _example.Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(x => x).ToArray();

            var sut = new Tree(orbits);

            // Act
            var result = sut.NodeExists(nodeId);

            // Assert
            Assert.IsType<bool>(result);
            Assert.True(result);
        }

        // 295936
        public void CountPaths_Part1_FindAnswer()
        {
            // Arrange
            var orbits = File.ReadAllLines(@"input.txt");
            var sut = new Tree(_example);

            // Act
            var result = sut.CountAllPaths();

            // Assert
            Assert.IsType<int>(result);
            Assert.Equal(295936, result);
        }

        private readonly string _example = @"COM)B
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

        [Fact]
        public void CanCreateTreeWithRootNode()
        {
            // Arrange
            var sut = new Tree("COM");

            // Act
            var result = sut.GetRootNode();

            // Assert
            Assert.IsType<TreeNode>(result);
            Assert.Equal("COM", result.Val);
        }


        [Fact]
        public void CountPaths_Part1_Example()
        {
            // Arrange
            string[] separator = {"\n", "\r\n", ", ", ","};
            var orbits = _example.Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(x => x).ToArray();
            var sut = new Tree(orbits);

            // Act
            var result = sut.CountAllPaths();

            // Assert
            Assert.IsType<int>(result);
            Assert.Equal(42, result);
        }

        [Fact]
        public void Node_G_FromExampleShouldxists()
        {
            // Arrange
            string[] separator = {"\n", "\r\n", ", ", ","};
            var orbits = _example.Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(x => x).ToArray();
            var sut = new Tree(orbits);

            // Act
            var result = sut.NodeExists("G");

            // Assert
            Assert.IsType<bool>(result);
            Assert.True(result);
        }

        [Fact]
        public void NodeShouldNotExists()
        {
            // Arrange
            var sut = new Tree(_example);

            // Act
            var result = sut.NodeExists("O");

            // Assert
            Assert.IsType<bool>(result);
            Assert.False(result);
        }
    }
}