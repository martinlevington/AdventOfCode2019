using System.Linq;
using Day_03_2019_Code;
using Xunit;

namespace Day_03_2019_Tests
{
    public class IntersectionDetectionTests
    {
        [Fact]
        public void HasIntersection()
        {
            // Arrange
            var grid1 = new PathGrid("R75,D30,R83,U83,L12,D49,R71,U7,L72");
            var grid2 = new PathGrid("U62,R66,U55,R34,D71,R55,D58,R83");
            grid1.ProcessInstructions();
            grid2.ProcessInstructions();
            var sut = new IntersectionDetection(grid1, grid2);

            //Act
            var results = sut.FindIntersections();

            //Assert
            Assert.NotEmpty(results);
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

            //Act
            var results = sut.FindIntersections();

            //Assert
            Assert.NotEmpty(results);
            Assert.Equal(2, results.Count());
        }


        [Fact]
        public void TraceStepsToPoint()
        {
            // Arrange
            var grid1 = new PathGrid("R8,U5,L5,D3");
            var grid2 = new PathGrid("U7,R6,D4,L4");
            grid1.ProcessInstructions();
            grid2.ProcessInstructions();

            //Act
            var steps = grid1.TraceStepsToPoint((3, 3));

            //Assert
            Assert.Equal(20, steps);
        }
    }
}