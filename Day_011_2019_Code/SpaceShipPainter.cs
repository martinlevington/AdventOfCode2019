using System;
using SharedCode;
using SharedCode.Robots;

namespace Day_11_2019_Code
{
    public class SpaceShipPainter
    {
        private readonly Robot _robot;
        private readonly SpaceShipHull _spaceShip;

        public SpaceShipPainter(Robot robot, SpaceShipHull spaceShip)
        {
            _robot = robot;
            _spaceShip = spaceShip;
        }


        public void PaintHull()
        {
            while (!_robot.IsFinished())
            {
                if (_spaceShip.GetPaintedSquareColour(_robot.GetPosition()) == PaintColour.Black)
                {
                    _robot.AddInput(0);
                }
                else if (_spaceShip.GetPaintedSquareColour(_robot.GetPosition()) == PaintColour.White)
                {
                    _robot.AddInput(1);
                }

                var instruction = _robot.Process();

                switch (instruction.GetDirection())
                {
                    case Turn.Left:
                        _robot.TurnLeft();
                        break;
                    case Turn.Right:
                        _robot.TurnRight();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                _spaceShip.PaintSquare(_robot.GetPosition(), instruction.GetPaintColour());
                _robot.MoveForward(1);
            }
        }
    }
}