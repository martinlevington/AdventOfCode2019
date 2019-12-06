using Day_06_2019_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Day_06_2019_Tests
{
    public class Part2Tests
    {

        [Fact]
        public void A()
        {
            string[] separator = { "\n", "\r\n", ", ", "," };
            var orbits = example.Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(x => x).ToArray();
            var sut = new Tree(orbits);

            // Act
            var result = sut.HopsToSanta();

            // Assert
            Assert.IsType<int>(result);
            Assert.Equal(4, result);

        }


        string example = @"COM)B
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
    }
}
