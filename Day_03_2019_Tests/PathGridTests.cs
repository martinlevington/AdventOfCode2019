using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Day_03_2019_Code
{
    public class PathGridTests
    {

        [Fact]
        public void StepsToPoint_ShouldBe610()
        {
            // Arrange
            var grid1 = new PathGrid("R75,D30,R83,U83,L12,D49,R71,U7,L72");
            var grid2 = new PathGrid("U62,R66,U55,R34,D71,R55,D58,R83");
            grid1.ProcessInstructions();
            grid2.ProcessInstructions();

            var intersectionDetection = new IntersectionDetection(grid1, grid2);
            var interSections = intersectionDetection.FindIntersections();

            //Act
            var leastSteps = int.MaxValue;
            foreach (var interSection in interSections)
            {
                var stepToIntersection = grid1.TraceStepsToPoint((interSection.Item1, interSection.Item2)) +
                            grid2.TraceStepsToPoint((interSection.Item1, interSection.Item2));

                if (leastSteps > stepToIntersection)
                {
                    leastSteps = stepToIntersection;
                }
            }

            //Assert
            Assert.Equal(610, leastSteps);

        }

        [Fact]
        public void StepsToPoint_Should410()
        {
            // Arrange
            var grid1 = new PathGrid("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51");
            var grid2 = new PathGrid("U98,R91,D20,R16,D67,R40,U7,R15,U6,R7");
            grid1.ProcessInstructions();
            grid2.ProcessInstructions();

            var intersectionDetection = new IntersectionDetection(grid1, grid2);
            var interSections = intersectionDetection.FindIntersections();

            //Act
            var leastSteps = int.MaxValue;
            foreach (var interSection in interSections)
            {
                var stepToIntersection = grid1.TraceStepsToPoint((interSection.Item1, interSection.Item2)) +
                                         grid2.TraceStepsToPoint((interSection.Item1, interSection.Item2));

                if (leastSteps > stepToIntersection)
                {
                    leastSteps = stepToIntersection;
                }
            }

            //Assert
            Assert.Equal(410, leastSteps);

        }
    }
}
