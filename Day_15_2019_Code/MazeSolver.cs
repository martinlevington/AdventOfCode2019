using System;
using System.Collections.Generic;
using System.Linq;
using SharedCode;
using SharedCode.Robots;
using Utils;

namespace Day_15_2019_Code
{
    public class MazeSolver
    {
        private readonly IAreaSize _area;
        private readonly Dictionary<(int, int), int> _path = new Dictionary<(int, int), int>();
        private readonly Robot _robot;

        private readonly Stack<MovementState> _validMoves = new Stack<MovementState>();
        private readonly List<(int, int)> _visited = new List<(int, int)>();
        private readonly AreaTextVisualiser _visualiser;

        private Movement _currentMovement = Movement.North;
        private bool foundDestination;

        public MazeSolver(Robot robot, IAreaSize area, AreaTextVisualiser visualiser)
        {
            _robot = robot;
            _area = area;
            _visualiser = visualiser;
        }


        public int Solve((int, int) startingPoint)
        {
            var currentDistance = 0;
            foundDestination = false;

            _robot.SetPosition(startingPoint);
            _robot.SetDirection(Direction.Up);
            _validMoves.Push(new MovementState(Movement.North, _robot.GetState(), currentDistance, startingPoint));
            _area.AddElement(startingPoint, 'O');

            MovementState previous = null;
            while (true)
            {
                DrawCurrentMaze(_robot.GetPosition());


                if (!_visited.Contains(_robot.GetPosition()))
                {
                    _visited.Add(_robot.GetPosition());
                }

                // find all possible direction we can move in
                foreach (var move in EnumUtil.GetValues<Movement>())
                {
                    var moveInfo = _robot.TestMovement(move);
                    if (moveInfo.CanMove && !_visited.Contains(moveInfo.Position))
                    {
                        _validMoves.Push(new MovementState(move, _robot.GetState(), currentDistance + 1,
                            _robot.GetPosition()));
                    }
                    else if (!moveInfo.CanMove && !_visited.Contains(moveInfo.Position))
                    {
                        _area.AddElement(moveInfo.Position, '#');
                    }
                }

                // pick a direction 
                var currentMove = _validMoves.Pop();
            

                foreach (var i in _path.Where(d => currentMove.Distance < d.Value).ToList())
                {
                    _path.Remove(i.Key);
                  //  _area.RemoveElement(i.Key);
                    _area.AddElement(i.Key, '.');
                }

                if (currentMove.Distance >= currentDistance)
                {
                    if (_robot.GetPosition() != startingPoint)
                    {
                        _area.AddElement(_robot.GetPosition(), '+');
                    }
                }


                currentDistance = currentMove.Distance;
                _robot.SetState(currentMove.State);
                _robot.SetPosition(currentMove.RobotPosition);

                var result = _robot.Move(currentMove.Move);

                if (_path.ContainsKey(currentMove.RobotPosition))
                {
                    _path[currentMove.RobotPosition] = currentDistance;
                }
                else
                {
                    _path.Add(currentMove.RobotPosition, currentDistance);
                }

               
                previous = currentMove;

                if (result == 2)
                {
                    _area.AddElement(_robot.GetPosition(), 'X');

                    foreach (var p in _path.OrderBy(x => x.Value).ToList())
                    {
                        Console.WriteLine(p.Value + " : " + p.Key);
                    }

                    return _path.Count();
                    break;
                }
            }
        }

        private void DrawCurrentMaze((int, int) currentPosition)
        {
            var drawing = _visualiser.Draw(currentPosition);
            var decodeImgLines = drawing.Split(_visualiser.GetLineEnd().First());
            //     Thread.Sleep(50);
            Console.Clear();
            Console.WriteLine("------------------------");
            foreach (var line in decodeImgLines)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("===============END=================");
        }

        public void NextMovement()
        {
            switch (_currentMovement)
            {
                case Movement.North:
                    _currentMovement = Movement.East;
                    break;
                case Movement.East:
                    _currentMovement = Movement.South;
                    break;
                case Movement.South:
                    _currentMovement = Movement.West;
                    break;
                case Movement.West:
                    _currentMovement = Movement.North;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}