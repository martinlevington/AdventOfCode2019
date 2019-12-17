using System;
using System.Collections.Generic;
using System.Text;

namespace SharedCode.Robots
{
    public class MovementState
    {
        public Movement Move { get; }
        public string State { get; }
        public int Distance { get; }
        public (int, int) RobotPosition { get; }


        public MovementState(Movement move, string state, int distance, (int,int) robotPosition)
        {
            Move = move;
            State = state;
            Distance = distance;
            RobotPosition = robotPosition;
        }
    }
}
