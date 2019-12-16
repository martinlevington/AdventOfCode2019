using System;
using System.Collections.Generic;
using System.Linq;
using SharedCode;
using SharedCode.Robots;

namespace Day_15_2019_Code
{
    public class MazeSolver
    {
        private readonly IAreaSize _area;
        private readonly AreaTextVisualiser _visualiser;
        private readonly Robot _robot;

        private Movement _currentMovement = Movement.North;
        private Dictionary<(int,int), List<Movement>> _visited = new Dictionary<(int, int), List<Movement>>();

        public MazeSolver(Robot robot, IAreaSize area, AreaTextVisualiser visualiser)
        {
            _robot = robot;
            _area = area;
            _visualiser = visualiser;
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

        public void Solve()
        {
            var foundDestination = false;
            var currentPosition = (0, 0);
            while (!foundDestination)
            {
                // give instruction to robot
                _robot.AddInput((int) _currentMovement);

                SetRobotDirection(_currentMovement);
                _robot.MoveForward(1);
              

                if (_area.ElementExists(_robot.GetPosition()) && _area.GetElement(_robot.GetPosition()) == '#')
                {
                    _robot.MoveBackward(1);
                    NextMovement();
                    continue;
                }
                _area.AddElement(_robot.GetPosition(), 'R');
                _area.AddElement(currentPosition, 'o');
        
                Console.WriteLine("Current:" + currentPosition.Item1 + ","+ currentPosition.Item2);
                Console.WriteLine("Robot At:" + _robot.GetPosition().Item1 + ","+_robot.GetPosition().Item2);
             Console.WriteLine("Direction:"+_currentMovement);
                DrawCurrentMaze();

                var instruction = _robot.Process();

                switch (instruction.GetStatusCode())
                {
                    case 0: // hit wall
                       
                        _area.AddElement(_robot.GetPosition(), '#');
                        _robot.MoveBackward(1);
                        NextMovement();
                        break;
                    case 1: // robot can move that direction
                        _area.AddElement(_robot.GetPosition(), '.');
                        currentPosition = _robot.GetPosition();
                        if (_visited.ContainsKey(currentPosition))
                        {
                            if (!_visited[currentPosition].Contains(_currentMovement))
                            {
                                _visited[currentPosition].Add(_currentMovement);
                            }
                        }
                        else
                        {
                            _visited.Add(currentPosition,new List<Movement>(){_currentMovement});
                        }

                        _currentMovement = Movement.West;
                        break;
                    case 2:
                        _area.AddElement(_robot.GetPosition(), 'D');
                        currentPosition = _robot.GetPosition();
                        foundDestination = true;
                        break;
                    default:
                        throw new Exception("Error unknown status code.");
                        break;
                }

             //   _area.AddElement(currentPosition, '.');


            }
        }

        private void DrawCurrentMaze()
        {
            var drawing = _visualiser.Draw();
            var decodeImgLines = drawing.Split(_visualiser.GetLineEnd().First());
            Console.WriteLine("------------------------");
            foreach(var line in decodeImgLines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("===============END=================");
        }

        public void SetRobotDirection(Movement movement)
        {
            switch (movement)
            {
                case Movement.North:
                    _robot.SetDirection(Direction.Down);
                    break;
                case Movement.East:
                    _robot.SetDirection(Direction.Left);
                    break;
                case Movement.South:
                    _robot.SetDirection(Direction.Up);
                    break;
                case Movement.West:
                    _robot.SetDirection(Direction.Right);
                    break;
                default:
                    break;
            }
        }
    }
}