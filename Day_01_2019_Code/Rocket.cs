using System;
using System.Collections;
using System.Collections.Generic;

namespace Day_01_2019_Code
{

   

    public class Rocket
    {
        private List<IRocketModule> _rocketModules;
        private IFuelCalculator _fuelCalculator;

        public Rocket(IFuelCalculator fuelCalculator)
        {
            _fuelCalculator = fuelCalculator;
            _rocketModules = new List<IRocketModule>();
        }

        public void AddModule(IRocketModule module)
        {
            _rocketModules.Add(module);

        }

        public int CalculateRequiredFuel()
        {
            int totalRequiredFuel = 0;
            foreach(var module in _rocketModules)
            {
                totalRequiredFuel += _fuelCalculator.RequiredFuel(module.Weight);
            }

            return totalRequiredFuel;
        }
    }
}
