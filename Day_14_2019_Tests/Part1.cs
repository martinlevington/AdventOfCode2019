using System;
using System.Linq;
using Day_14_2019_Code;
using Xunit;

namespace Day_14_2019_Tests
{
    public class Part1
    {
        private readonly string[] _separators = {"\r\n", "\n"};

        [Fact]
        public void CanCreateChemicalEquationFromString()
        {
            //Arrange
            var input = @"
7 A, 1 E => 1 FUEL";

            var lines = input.Split(_separators, StringSplitOptions.RemoveEmptyEntries);

            //Act
            var chemicalEq = new ChemicalEquation(lines.First());

            //Assert
            Assert.Equal(7, chemicalEq.Inputs.Find(x => x.Amount == 7).Amount);
            Assert.Equal("A", chemicalEq.Inputs.Find(x => x.Unit == "A").Unit);
        }

        [Fact]
        public void Test_13312_ore_for_1_fuel()
        {
            //Arrange
            var input = @"157 ORE => 5 NZVS
165 ORE => 6 DCFZ
44 XJWVT, 5 KHKGT, 1 QDVJ, 29 NZVS, 9 GPVTF, 48 HKGWZ => 1 FUEL
12 HKGWZ, 1 GPVTF, 8 PSHF => 9 QDVJ
179 ORE => 7 PSHF
177 ORE => 5 HKGWZ
7 DCFZ, 7 PSHF => 2 XJWVT
165 ORE => 2 GPVTF
3 DCFZ, 7 NZVS, 5 HKGWZ, 10 PSHF => 8 KHKGT";

            var lines = input.Split(_separators, StringSplitOptions.RemoveEmptyEntries);
            var reader = new EquationReader(lines.ToArray());
            var solver = new EquationSolver(reader.Equations);

            //Act
            var result = solver.GetRequiredOre(reader.Equations["FUEL"], 1);

            //Assert
            Assert.Equal(13312, result);
        }


        [Fact]
        public void Test_13312_ore_for_1_fuel_producer()
        {
            //Arrange
            var input = @"157 ORE => 5 NZVS
165 ORE => 6 DCFZ
44 XJWVT, 5 KHKGT, 1 QDVJ, 29 NZVS, 9 GPVTF, 48 HKGWZ => 1 FUEL
12 HKGWZ, 1 GPVTF, 8 PSHF => 9 QDVJ
179 ORE => 7 PSHF
177 ORE => 5 HKGWZ
7 DCFZ, 7 PSHF => 2 XJWVT
165 ORE => 2 GPVTF
3 DCFZ, 7 NZVS, 5 HKGWZ, 10 PSHF => 8 KHKGT";

            var lines = input.Split(_separators, StringSplitOptions.RemoveEmptyEntries);
            var reader = new EquationReader(lines.ToArray());
            var solver = new EquationSolver(reader.Equations);

            //Act
            var result = solver.Consume(reader.Equations["FUEL"].Output.Unit, 1);

            //Assert
            Assert.Equal(13312, solver.GetConsumedChemicals("ORE"));
        }

        [Fact]
        public void Test_Consume()
        {
            //Arrange
            var input = @"10 ORE => 10 A
1 ORE => 1 B
7 A, 1 B => 1 C
7 A, 1 C => 1 D
7 A, 1 D => 1 E
7 A, 1 E => 1 FUEL";

            var lines = input.Split(_separators, StringSplitOptions.RemoveEmptyEntries);
            var reader = new EquationReader(lines.ToArray());
            var solver = new EquationSolver(reader.Equations);

            //Act
            var result = solver.Consume(reader.Equations["FUEL"].Output.Unit, 1);

            //Assert
            Assert.Equal(31, solver.GetConsumedChemicals("ORE"));
        }

        [Fact]
        public void Test2()
        {
            //Arrange
            var input = @"10 ORE => 10 A
1 ORE => 1 B
7 A, 1 B => 1 C
7 A, 1 C => 1 D
7 A, 1 D => 1 E
7 A, 1 E => 1 FUEL";

            var lines = input.Split(_separators, StringSplitOptions.RemoveEmptyEntries);
            var reader = new EquationReader(lines.ToArray());
            var solver = new EquationSolver(reader.Equations);

            //Act
            var result = solver.GetRequiredOre(reader.Equations["FUEL"], 1);

            //Assert
            Assert.Equal(31, result);
        }

        [Fact]
        public void xx_Surplus_For_1_Fuel()
        {
            //Arrange
            var input = @"10 ORE => 10 A
1 ORE => 1 B
7 A, 1 B => 1 C
7 A, 1 C => 1 D
7 A, 1 D => 1 E
7 A, 1 E => 1 FUEL";

            var lines = input.Split(_separators, StringSplitOptions.RemoveEmptyEntries);
            var reader = new EquationReader(lines.ToArray());
            var solver = new EquationSolver(reader.Equations);

            //Act
            var result = solver.GetRequiredOre(reader.Equations["FUEL"], 1);

            //Assert
            Assert.Equal(31, result);
            Assert.Equal(2, solver.GetSurplus("A"));
        }
    }
}