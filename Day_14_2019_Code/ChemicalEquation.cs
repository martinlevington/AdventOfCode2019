using System;
using System.Collections.Generic;
using System.Text;

namespace Day_14_2019_Code
{
    public class ChemicalEquation : IEquation
    {
        public List<IEquationElement> Inputs { get; }
        public IEquationElement Output { get; }


        public ChemicalEquation(string equation)
        {
            Inputs = new List<IEquationElement>();

            // expected format
            // 7 A, 1 E => 1 FUEL
            string[] separator =  {Equations.ToString(Equations.Sign.Makes)}; 
            var equationParts = equation.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            if(equationParts.Length != 2) throw new Exception("Error cannot make equation, incorrect number of parts");
            Output = new Chemical(equationParts[1]);

            var makesParts = equationParts[0].Split(new string[] {",", ", "}, StringSplitOptions.RemoveEmptyEntries);

            foreach (var chemical in makesParts)
            {
                Inputs.Add( new Chemical(chemical));
            }
          
     


        }

    }
}
