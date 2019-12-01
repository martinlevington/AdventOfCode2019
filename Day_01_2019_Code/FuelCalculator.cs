using System;
namespace Day_01_2019_Code
{
    public class FuelCalculator : IFuelCalculator
    {
       

        public int RequiredFuel(int weight)
        {
            int answer = 0;

            answer = (int)(weight / 3 - 2);

            return answer;
        }

    }
}
