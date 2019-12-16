using System;

namespace SharedCode.Robots
{
    public class Robot
    {

        private readonly IIntcode _computer;
        private readonly IBuffer _outputBuffer;
        private readonly IBuffer _inputBuffer;
        private Direction _direction = Direction.Up;
        private int _currentX = 0;
        private int _currentY = 0;

        public Robot(IIntcode computer,  IBuffer outputBuffer, IBuffer inputBuffer)
        {
            _computer = computer;
            _outputBuffer = outputBuffer;
            _inputBuffer = inputBuffer;
        }

        public RobotInstruction Process()
        {
            _computer.Wake();
            _computer.Process();

            return _outputBuffer.Count >=2 ? new RobotInstruction(_outputBuffer.GetValue(), _outputBuffer.GetValue()) : new RobotInstruction(_outputBuffer.GetValue());
        }

        public bool IsFinished()
        {
            return !_computer.IsRunning();
        }

        public void AddInput(int value)
        {
            _inputBuffer.Add(value);
        }

        public (int,int) GetPosition()
        {
            return (_currentX, _currentY);
        }

        public void MoveForward(int distance)
        {
            switch (_direction)
            {
                case Direction.Up:
                    _currentY -= distance;
                    break;
                case Direction.Left:
                    _currentX -= distance;
                    break;
                case Direction.Down:
                    _currentY += distance;
                    break;
                case Direction.Right:
                    _currentX += distance;
                    break;
                default:
                    break;
            }
        }

        public void MoveBackward(int distance)
        {
            switch (_direction)
            {
                case Direction.Up:
                    _currentY += distance;
                    break;
                case Direction.Left:
                    _currentX += distance;
                    break;
                case Direction.Down:
                    _currentY -= distance;
                    break;
                case Direction.Right:
                    _currentX -= distance;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void TurnLeft()
        {
            switch (_direction)
            {
                case Direction.Up:
                    _direction = Direction.Left;
                    break;
                case Direction.Left:
                    _direction = Direction.Down;
                    break;
                case Direction.Down:
                    _direction = Direction.Right;
                    break;
                case Direction.Right:
                    _direction = Direction.Up;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void TurnRight()
        {
            switch (_direction)
            {
                case Direction.Up:
                    _direction = Direction.Right;
                    break;
                case Direction.Right:
                    _direction = Direction.Down;
                    break;
                case Direction.Down:
                    _direction = Direction.Left;
                    break;
                case Direction.Left:
                    _direction = Direction.Up;
                    break;
                default:
                    break;
            }
        }

        public void SetDirection(Direction direction)
        {
            _direction = direction;
        }
    }
}
