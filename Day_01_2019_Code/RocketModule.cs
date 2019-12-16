namespace Day_01_2019_Code
{
    public class RocketModule : IRocketModule
    {
        public RocketModule(int weight)
        {
            Weight = weight;
        }

        public int Weight { get; set; }
    }
}