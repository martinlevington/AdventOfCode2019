using System;
namespace Day_01_2019_Code
{
    public class RocketModule : IRocketModule
    {
        private int weight;

        public int Weight { get => weight; set => weight = value; }

        public RocketModule(int weight)
        {
            Weight = weight;
        }


    }
}
