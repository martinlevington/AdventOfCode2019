using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using SharedCode;
using SharedCode.Robots;
using Utils;

namespace Day_15_2019_Code
{
    public class MazeSolver
    {
        private readonly IAreaSize _area;
        private readonly Robot _robot;

        private readonly Stack<MovementState> _validMoves = new Stack<MovementState>();
        private readonly List<(int, int)> _visited = new List<(int, int)>();
        private readonly AreaTextVisualiser _visualiser;

        private Movement _currentMovement = Movement.North;

        private readonly Dictionary<(int, int), int> _path = new Dictionary<(int, int), int>();
        private readonly Dictionary<(int, int), int> _shortestPath = new Dictionary<(int, int), int>();
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

            while (_validMoves.Count > 0)
            {
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
                    
                }

                // pick a direction 
                var currentMove = _validMoves.Pop();

                foreach (var i in _path.Where(d => currentMove.Distance < d.Value).ToList())
                {
                    _path.Remove(i.Key);
                    _area.AddElement(i.Key, '.');
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
                _area.AddElement(currentMove.RobotPosition, '+');
                DrawCurrentMaze(currentMove.RobotPosition, startingPoint);

                if (result == 2)
                {
                    foundDestination = true;
                    foreach (var pathPart in _path.OrderBy(x => x.Value))
                    {
                        _shortestPath.Add(pathPart.Key, pathPart.Value);
                    }
                }
            }

            DrawCurrentMaze(_robot.GetPosition(), startingPoint);
            if (foundDestination)
            {
                return _shortestPath.Count;
            }

            return -1;
        }

        private void DrawCurrentMaze((int, int) currentPosition, (int, int) startingPoint)
        {
            //foreach (var pathPart in _path.OrderBy(x => x.Value))
            //{
            //    if (pathPart.Key != startingPoint)
            //    {
            //        _area.AddElement(pathPart.Key, '.');
            //    }
            //}

            if (_path.Count > 0)
            {
                _area.AddElement(_path.First().Key, 'O');
            }

            if (_shortestPath.Count > 0)
            {
                foreach (var pathPart in _shortestPath.OrderBy(x => x.Value))
                {
                    if (pathPart.Key != startingPoint)
                    {
                        _area.AddElement(pathPart.Key, '+');
                    }
                }

                _area.AddElement(_shortestPath.First().Key, 'O');
                _area.AddElement(_shortestPath.Last().Key, 'X');
            }

            Thread.Sleep(100);
            Console.Clear();
            _visualiser.Draw(currentPosition, '#', '*');
          
         
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