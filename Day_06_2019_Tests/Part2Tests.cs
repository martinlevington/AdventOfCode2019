using System;
using System.Linq;
using Day_06_2019_Code;
using Xunit;

namespace Day_06_2019_Tests
{
    public class Part2Tests
    {
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
K)L
K)YOU
I)SAN";

        [Fact]
        public void A()
        {
            string[] separator = {"\n", "\r\n", ", ", ","};
            var orbits = _example.Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(x => x).ToArray();
            var sut = new Tree(orbits);

            // Act
            var result = sut.HopsToSanta();

            // Assert
            Assert.IsType<int>(result);
            Assert.Equal(4, result);
        }
    }
}