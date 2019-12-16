using System.Collections.Generic;
using System.Linq;

namespace Day_01_2019_Code
{
    public class Rocket
    {
        private readonly IFuelCalculator _fuelCalculator;
        private readonly List<IRocketModule> _rocketModules;

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
            return _rocketModules.Sum(module => _fuelCalculator.RequiredFuel(module.Weight));
        }
    }
}