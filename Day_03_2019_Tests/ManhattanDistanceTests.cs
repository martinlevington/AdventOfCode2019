using System.Linq;
using Day_03_2019_Code;
using Xunit;

namespace Day_03_2019_Tests
{
    public class ManhattanDistanceTests
    {
        [Fact]
        public void CheckDistanceIs_135_toNearestIntersection()
        {
            // Arrange
            var grid1 = new PathGrid("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51");
            var grid2 = new PathGrid("U98,R91,D20,R16,D67,R40,U7,R15,U6,R7");
            grid1.ProcessInstructions();
            grid2.ProcessInstructions();
            var sut = new IntersectionDetection(grid1, grid2);
            var calculator = new ManhattanDistance();

            //Act
            var results = sut.FindIntersections();
            var shortestDistance = calculator.CalculateShortestFromOrigin(results);

            //Assert
            Assert.NotEmpty(results);
            Assert.Equal(135, shortestDistance);
        }

        [Fact]
        public void CheckDistanceIs_159_toNearestIntersection()
        {
            // Arrange
            var grid1 = new PathGrid("R75,D30,R83,U83,L12,D49,R71,U7,L72");
            var grid2 = new PathGrid("U62,R66,U55,R34,D71,R55,D58,R83");
            grid1.ProcessInstructions();
            grid2.ProcessInstructions();
            var sut = new IntersectionDetection(grid1, grid2);
            var calculator = new ManhattanDistance();

            //Act
            var results = sut.FindIntersections();
            var shortestDistance = calculator.CalculateShortestFromOrigin(results);

            //Assert
            Assert.NotEmpty(results);
            Assert.Equal(159, shortestDistance);
        }


        [Fact]
        public void HasTwoIntersection()
        {
            // Arrange
            var grid1 = new PathGrid("R8,U5,L5,D3");
            var grid2 = new PathGrid("U7,R6,D4,L4");
            grid1.ProcessInstructions();
            grid2.ProcessInstructions();

            var sut = new IntersectionDetection(grid1, grid2);

            var calculator = new ManhattanDistance();

            //Act
            var results = sut.FindIntersections();

            //Assert
            Assert.NotEmpty(results);
            Assert.Equal(2, results.Count());
        }
    }
}