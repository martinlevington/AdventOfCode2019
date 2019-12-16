namespace SharedCode.Robots
{
    public class RobotInstruction
    {
        private readonly int _part1;
        private readonly int _part2;

        public RobotInstruction(long first, long second)
        {
            _part1 =  (int) first;
            _part2 =  (int) second;
        }

        public RobotInstruction(long first)
        {
            _part1 =  (int) first;
        }

        public PaintColour GetPaintColour()
        {
            return (PaintColour)_part2;
        }

        public Turn GetDirection()
        {
            return (Turn)_part1;
        }

        public int GetStatusCode()
        {
            return _part1;
        }
    }
}
