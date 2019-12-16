﻿using System;
using System.Linq;
using Day_14_2019_Code;
using Xunit;

namespace Day_14_2019_Tests
{
    public class Part2
    {
        private readonly string[] _separators = {"\r\n", "\n"};

        [Fact]
        public void Test_Fuel_From_1TrillionOre_Example1()
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
            //var result = solver.GetRequiredOre(reader.Equations["FUEL"], 1);
            // 1,000,000,000,000
            var result = solver.CalculateFuelFromOre(1000000000000);


            //Assert
            Assert.Equal(82892753, result);
        }


        [Fact]
        public void Test_Fuel_From_1TrillionOre_Example3()
        {
            //Arrange
            var input = @"171 ORE => 8 CNZTR
7 ZLQW, 3 BMBT, 9 XCVML, 26 XMNCP, 1 WPTQ, 2 MZWV, 1 RJRHP => 4 PLWSL
114 ORE => 4 BHXH
14 VRPVC => 6 BMBT
6 BHXH, 18 KTJDG, 12 WPTQ, 7 PLWSL, 31 FHTLT, 37 ZDVW => 1 FUEL
6 WPTQ, 2 BMBT, 8 ZLQW, 18 KTJDG, 1 XMNCP, 6 MZWV, 1 RJRHP => 6 FHTLT
15 XDBXC, 2 LTCX, 1 VRPVC => 6 ZLQW
13 WPTQ, 10 LTCX, 3 RJRHP, 14 XMNCP, 2 MZWV, 1 ZLQW => 1 ZDVW
5 BMBT => 4 WPTQ
189 ORE => 9 KTJDG
1 MZWV, 17 XDBXC, 3 XCVML => 2 XMNCP
12 VRPVC, 27 CNZTR => 2 XDBXC
15 KTJDG, 12 BHXH => 5 XCVML
3 BHXH, 2 VRPVC => 7 MZWV
121 ORE => 7 VRPVC
7 XCVML => 6 RJRHP
5 BHXH, 4 VRPVC => 5 LTCX";

            var lines = input.Split(_separators, StringSplitOptions.RemoveEmptyEntries);
            var reader = new EquationReader(lines.ToArray());
            var solver = new EquationSolver(reader.Equations);

            //Act
            // 1,000,000,000,000
            var result = solver.CalculateFuelFromOre(1000000000000);

            //Assert
            Assert.Equal(460664, result);
        }
    }
}