using System.Collections.Generic;

namespace Day_14_2019_Code
{
    public class EquationReader
    {
        public EquationReader(string[] lines)
        {
            foreach (var line in lines)
            {
                var eq = new ChemicalEquation(line);

                Equations.Add(eq.Output.Unit, eq);
            }
        }

        public Dictionary<string, IEquation> Equations { get; } = new Dictionary<string, IEquation>();
    }
}