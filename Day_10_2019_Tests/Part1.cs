using System;
using Day_10_2019_Code;
using Xunit;

namespace Day_10_2019_Tests
{
    public class Part1
    {
        private string _map1Data = @".#..#
.....
#####
....#
...##";

        [Fact]
        public void Part1_InitalMap()
        {
            // Arrange
            var  expectedResult = 8;
            var mapReader = new MapReader(_map1Data);
            var map = new AsteroidMap(mapReader.ToDictionary());
            //Act
            var result = map.MapAllVisibleAsteroids();


            //Assert
            Assert.Equal(expectedResult,result);
            Assert.Equal((3,4), map.GetBestAsteroidForBase());

        }

        
        [Fact]
        public void Part1_LargerExample1()
        {
            // Arrange
            var mapData = @"......#.#.
#..#.#....
..#######.
.#.#.###..
.#..#.....
..#....#.#
#..#....#.
.##.#..###
##...#..#.
.#....####";
            var  expectedResult = 33;
            var mapReader = new MapReader(mapData);
            var map = new AsteroidMap(mapReader.ToDictionary());
            //Act
            var result = map.MapAllVisibleAsteroids();


            //Assert
            Assert.Equal(expectedResult,result);
            Assert.Equal((5,8), map.GetBestAsteroidForBase());

        }

        [Fact]
        public void Part1_LargerExample2()
        {
            // Arrange
            var mapData = @"#.#...#.#.
.###....#.
.#....#...
##.#.#.#.#
....#.#.#.
.##..###.#
..#...##..
..##....##
......#...
.####.###.";
            var  expectedResult = 35;
            var mapReader = new MapReader(mapData);
            var map = new AsteroidMap(mapReader.ToDictionary());
            //Act
            var result = map.MapAllVisibleAsteroids();


            //Assert
            Assert.Equal(expectedResult,result);
            Assert.Equal((1,2), map.GetBestAsteroidForBase());

        }

        [Fact]
        public void Part1_LargerExample4()
        {
            // Arrange
            var mapData = @".#..##.###...#######
##.############..##.
.#.######.########.#
.###.#######.####.#.
#####.##.#.##.###.##
..#####..#.#########
####################
#.####....###.#.#.##
##.#################
#####.##.###..####..
..######..##.#######
####.##.####...##..#
.#####..#.######.###
##...#.##########...
#.##########.#######
.####.#.###.###.#.##
....##.##.###..#####
.#.#.###########.###
#.#.#.#####.####.###
###.##.####.##.#..##";
            var  expectedResult = 210;
            var mapReader = new MapReader(mapData);
            var map = new AsteroidMap(mapReader.ToDictionary());
            //Act
            var result = map.MapAllVisibleAsteroids();

            //Assert
            Assert.Equal(expectedResult,result);
            Assert.Equal((11,13), map.GetBestAsteroidForBase());

        }

        

    }
}
