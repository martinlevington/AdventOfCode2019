using System;

namespace Day_14_2019_Code
{
    public class Chemical : IEquationElement
    {
        public Chemical(int amount, string unit)
        {
            Amount = amount;
            Unit = unit;
        }

        public Chemical(string chemical)
        {
            checked
            {
                var parts = chemical.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

                Amount = Convert.ToInt32(parts[0]);
                Unit = parts[1];
            }
        }

        public int Amount { get; }
        public string Unit { get; }
    }
}