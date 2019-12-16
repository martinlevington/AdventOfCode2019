using System;
using System.Collections.Generic;
using System.Text;
using Day_10_2019_Code;
using Xunit;

namespace Day_10_2019_Tests
{
    public class Part2
    {

        [Fact]
        public void Part2_InitalMap()
        {
            // Arrange
            var mapData = @".#..#
.....
#####
....#
...##";
            var  expectedResult = 8;
            var mapReader = new MapReader(mapData);
            var map = new AsteroidMap(mapReader.ToDictionary());
            //Act
          //  map.CalculateAnglesToAsteroidsForStation((3,4));
          //  map.CalculateDistancesToAsteroidsForStation((3,4));
            map.MapAllVisibleAsteroids();


            //Assert
           // Assert.Equal(expectedResult,result);
            Assert.Equal((3,4), map.GetBestAsteroidForBase());

        }

        [Fact]
        public void Part2_Vaporise_VisibleOnly1Pass()
        {
            // Arrange
            var mapData = @".#..#
.....
#####
....#
...##";
       
            var mapReader = new MapReader(mapData);
            var map = new AsteroidMap(mapReader.ToDictionary());
            //Act
            map.MapAllVisibleAsteroids();
        
            map.VaporiseVisibleAsteroids((3,4), 2);
            var r = map.LoggedAsteroid;

            //Assert
            // Assert.Equal(expectedResult,result);
            Assert.Equal(2, map.GetAsteroidCount());

        }

        [Fact]
        public void Part2_Vaporise_All_ButBase()
        {
            // Arrange
            var mapData = @".#..#
.....
#####
....#
...##";
            var mapReader = new MapReader(mapData);
            var map = new AsteroidMap(mapReader.ToDictionary());
            //Act
            map.MapAllVisibleAsteroids();
        
            map.VaporiseAllVisibleAsteroids((3,4), 1);
            var r = map.LoggedAsteroid;

            //Assert
            Assert.Equal(1, map.GetAsteroidCount());

        }


         [Fact]
        public void Part2_Vaporise_CheckAngle()
        {
            // Arrange
            var mapData = 
@"........#........
.................
.................        
........#........        
.................";

            var mapReader = new MapReader(mapData);
            var map = new AsteroidMap(mapReader.ToDictionary());
            //Act
            map.MapAllVisibleAsteroids();
        
            map.VaporiseVisibleAsteroids((8,3), 1);
            var r = map.LoggedAsteroid;

            //Assert
            
            Assert.Equal(1, map.GetAsteroidCount());
            Assert.Equal((8,0), r);

        }

        [Fact]
        public void Part2_Vaporise_CheckAngleStillCorrectWith2()
        {
            // Arrange
            var mapData = 
@"........#........
........#........
.................        
........#........        
.................";

            var mapReader = new MapReader(mapData);
            var map = new AsteroidMap(mapReader.ToDictionary());
            //Act
            map.MapAllVisibleAsteroids();
            map.VaporiseVisibleAsteroids((8,3), 1);
            var r = map.LoggedAsteroid;

            //Assert
            Assert.Equal(2, map.GetAsteroidCount());
            Assert.Equal((8,1), r);
        }


        [Fact]
        public void Part2_Vaporise_CheckAngleStillCorrectWith4()
        {
            // Arrange
            var mapData = 
                @"........#........
........#........
................#
........#........
#................";

            var mapReader = new MapReader(mapData);
            var map = new AsteroidMap(mapReader.ToDictionary());
            //Act
            map.MapAllVisibleAsteroids();
            map.VaporiseVisibleAsteroids((8,3), 1);
            var r = map.LoggedAsteroid;

            //Assert
            Assert.Equal(2, map.GetAsteroidCount());
            Assert.Equal((8,1), r);
        }




    }
}
