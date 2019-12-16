namespace Day_01_2019_Code
{
    public class FuelCalculator : IFuelCalculator
    {
        public int RequiredFuel(int weight)
        {
            var answer = 0;

            answer = weight / 3 - 2;

            if (answer > 0)
            {
                return answer + RequiredFuel(answer);
            }

            return 0;
        }
    }
}