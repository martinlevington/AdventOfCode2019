using System.Collections.Generic;
using Day_12_2019_Code;
using Xunit;

namespace Day_12_2019_Tests
{
    public class Part1
    {
        // example
        //<x=-1, y=0, z=2>
        //<x=2, y=-10, z=-7>
        //<x=4, y=-8, z=8>
        //<x=3, y=5, z=-1>

        private readonly List<Moon> _moons;

        public Part1()
        {
            _moons = new List<Moon>
            {
                new Moon(-1, 0, 2),
                new Moon(2, -10, -7),
                new Moon(4, -8, 8),
                new Moon(3, 5, -1)
            };
        }

        [Theory]
        [InlineData(-1, 0, 2, 0, 0, 0)]
        public void StepMoon_SetupCheck(int x, int y, int z, int expectedVelocityX, int expectedVelocityY,
            int expectedVelocityZ)
        {
            // Arrange

            //Act
            var sut = new NBody(_moons);

            //Assert
            Assert.Equal(x, sut.GetMoon(0).X);
            Assert.Equal(y, sut.GetMoon(0).Y);
            Assert.Equal(z, sut.GetMoon(0).Z);
            Assert.Equal(expectedVelocityX, sut.GetMoon(0).VelocityX);
            Assert.Equal(expectedVelocityY, sut.GetMoon(0).VelocityY);
            Assert.Equal(expectedVelocityZ, sut.GetMoon(0).VelocityZ);
        }

        [Theory]
        [InlineData(1, 3, -1, -1)]
        [InlineData(2, 3, -2, -2)]
        [InlineData(3, 0, -3, 0)]
        public void StepMoon_StepOneCheckVelocityMoon0(int numberOfSteps, int expectedVelocityX, int expectedVelocityY,
            int expectedVelocityZ)
        {
            // Arrange
            var moonIndex = 0;
            var sut = new NBody(_moons);
            var currentStep = 0;
            //Act
            while (currentStep < numberOfSteps)
            {
                sut.Step();
                currentStep++;
            }

            //Assert
            Assert.Equal(expectedVelocityX, sut.GetMoon(moonIndex).VelocityX);
            Assert.Equal(expectedVelocityY, sut.GetMoon(moonIndex).VelocityY);
            Assert.Equal(expectedVelocityZ, sut.GetMoon(moonIndex).VelocityZ);
        }

        [Theory]
        [InlineData(1, 2, -1, 1)]
        [InlineData(2, 5, -3, -1)]
        [InlineData(3, 5, -6, -1)]
        [InlineData(4, 2, -8, 0)]
        [InlineData(5, -1, -9, 2)]
        [InlineData(6, -1, -7, 3)]
        [InlineData(7, 2, -2, 1)]
        [InlineData(8, 5, 2, -2)]
        [InlineData(9, 5, 3, -4)]
        [InlineData(10, 2, 1, -3)]
        public void StepMoon_StepOneCheckPositionMoon0(int numberOfSteps, int expectedX, int expectedY, int expectedZ)
        {
            // Arrange
            var moonIndex = 0;
            var sut = new NBody(_moons);
            var currentStep = 0;
            //Act
            while (currentStep < numberOfSteps)
            {
                sut.Step();
                currentStep++;
            }

            //Assert
            Assert.Equal(expectedX, sut.GetMoon(moonIndex).X);
            Assert.Equal(expectedY, sut.GetMoon(moonIndex).Y);
            Assert.Equal(expectedZ, sut.GetMoon(moonIndex).Z);
        }

        [Theory]
        [InlineData(10, 179)]
        public void StepMoon_TotalEnergyAfter10Steps(int numberOfSteps, int expectedTotal)
        {
            // Arrange
            var sut = new NBody(_moons);
            var currentStep = 0;
            //Act
            while (currentStep < numberOfSteps)
            {
                sut.Step();
                currentStep++;
            }

            //Assert
            Assert.Equal(expectedTotal, sut.GetTotalEnergy());
        }


        // example
        //<x=-1, y=0, z=2>
        //<x=2, y=-10, z=-7>
        //<x=4, y=-8, z=8>
        //<x=3, y=5, z=-1>
        [Theory]
        [InlineData(866910349, -1, 0)]
        public void StepMoon_RepeatTest(int numberOfSteps, int expectedX, int expectedY)
        {
            // Arrange
            var sut = new NBody(_moons);
            var currentStep = 0;

            //Act
            while (currentStep < numberOfSteps)
            {
                sut.Step();
                currentStep++;
            }

            //Assert
            Assert.Equal(expectedX, sut.GetMoon(0).X);
            Assert.Equal(expectedY, sut.GetMoon(0).Y);
        }
    }
}