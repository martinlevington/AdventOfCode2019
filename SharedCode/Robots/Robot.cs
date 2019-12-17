using System;

namespace SharedCode.Robots
{
    public class Robot
    {
        private readonly IIntcode _computer;
        private readonly IBuffer _inputBuffer;
        private readonly IBuffer _outputBuffer;
        private int _currentX;
        private int _currentY;
        private Direction _direction = Direction.Up;

        public Robot(IIntcode computer, IBuffer outputBuffer, IBuffer inputBuffer)
        {
            _computer = computer;
            _outputBuffer = outputBuffer;
            _inputBuffer = inputBuffer;
        }

        public RobotInstruction Process()
        {
            _computer.Wake();
            _computer.Process();

            return _outputBuffer.Count >= 2
                ? new RobotInstruction(_outputBuffer.GetValue(), _outputBuffer.GetValue())
                : new RobotInstruction(_outputBuffer.GetValue());
        }

        public MovementResult TestMovement(Movement move)
        {
            AddInput((int) move);
            var instruction = Process();

            SetRobotDirection(move);
            MoveForward(1);

            switch (instruction.GetStatusCode())
            {
                case 0: // hit wall
                    var resultWall = new MovementResult(false, (_currentX, _currentY));
                    MoveBackward(1);
                    return resultWall;
                case 1: // robot can move that direction
                case 2:
                    var result = new MovementResult(true, (_currentX, _currentY));
                    AddInput((int) ReverseMovement(move));
                    instruction = Process();
                    if (instruction.GetStatusCode() != 1 && instruction.GetStatusCode() != 2)
                    {
                        throw new Exception("Error Robot should be able to move that way.");
                    }
                    MoveBackward(1);

                    return result;
                default:
                    throw new Exception("Error unknown status code.");
            }
        }

        public string GetState()
        {
            return _computer.CurrentState();
        }

        public void SetState(string state)
        {
            _computer.SetState(state);
        }

        public int Move(Movement move)
        {
            AddInput((int) move);
            var instruction = Process();
            SetRobotDirection(move);
            MoveForward(1);

            return instruction.GetStatusCode();
        }

        public void SetRobotDirection(Movement movement)
        {
            switch (movement)
            {
                case Movement.North:
                    SetDirection(Direction.Up);
                    break;
                case Movement.East:
                    SetDirection(Direction.Right);
                    break;
                case Movement.South:
                    SetDirection(Direction.Down);
                    break;
                case Movement.West:
                    SetDirection(Direction.Left);
                    break;
            }
        }

        private Movement ReverseMovement(Movement move)
        {
            switch (move)
            {
                case Movement.North:
                    return Movement.South;
                case Movement.East:
                    return Movement.West;
                case Movement.South:
                    return Movement.North;
                case Movement.West:
                    return Movement.East;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public bool IsFinished()
        {
            return !_computer.IsRunning();
        }

        public void AddInput(int value)
        {
            _inputBuffer.Add(value);
        }

        public (int, int) GetPosition()
        {
            return (_currentX, _currentY);
        }

        public void SetPosition((int, int) point)
        {
            _currentX = point.Item1;
            _currentY = point.Item2;
        }

        public void MoveForward(int distance)
        {
            switch (_direction)
            {
                case Direction.Up:
                    _currentY += distance;
                    break;
                case Direction.Left:
                    _currentX -= distance;
                    break;
                case Direction.Down:
                    _currentY -= distance;
                    break;
                case Direction.Right:
                    _currentX += distance;
                    break;
            }
        }

        public void MoveBackward(int distance)
        {
            switch (_direction)
            {
                case Direction.Up:
                    _currentY -= distance;
                    break;
                case Direction.Left:
                    _currentX += distance;
                    break;
                case Direction.Down:
                    _currentY += distance;
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
            }
        }

        public void SetDirection(Direction direction)
        {
            _direction = direction;
        }
    }
}