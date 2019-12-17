using System;
using System.Collections.Generic;
using System.Text;

namespace SharedCode.Robots
{
    public class MovementResult
    {
        public bool CanMove { get; }
        public (int, int) Position { get; }

        public MovementResult(bool canMove, (int, int) position)
        {
            CanMove = canMove;
            Position = position;
        }
    }
}
