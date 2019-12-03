using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace Day_03_2019_Code
{
    public class PathGrid
    {

        private Dictionary<(int,int), string> _gridPoints;
        private string _instructions;

        public PathGrid()
        {
            _gridPoints = new Dictionary<(int, int), string>();
        }


        public PathGrid(string instructions)
        {
            _gridPoints = new Dictionary<(int, int), string>();
            _instructions = instructions;
        }

        public int CurrentX { get; set; }
        public int CurrentY { get; set; }

        public void ProcessInstructions()
        {

            var rawInstructions = Strings.StringToEnumerableString(_instructions);
            var individualInstructions = ConvertToInstructions(rawInstructions);
            foreach (var individualInstruction in individualInstructions)
            {
                var currentInstruction = individualInstruction.Item1;
                switch (currentInstruction)
                {
                    case "U":
                        MoveUp(individualInstruction.Item2);
                        break;
                    case "D":
                        MoveDown(individualInstruction.Item2);
                        break;
                    case "L":
                        MoveLeft(individualInstruction.Item2);
                        break;
                    case "R":
                        MoveRight(individualInstruction.Item2);
                        break;
                    default:
                        throw new Exception("Error: Unknown Direction");
                }
            }
        }

        public int TraceStepsToPoint()
        {
            int steps = 0;

            var rawInstructions = Strings.StringToEnumerableString(_instructions);
            var individualInstructions = ConvertToInstructions(rawInstructions);
            foreach (var individualInstruction in individualInstructions)
            {
                var currentInstruction = individualInstruction.Item1;
                switch (currentInstruction)
                {
                    case "U":
                        MoveUp(individualInstruction.Item2);
                        break;
                    case "D":
                        MoveDown(individualInstruction.Item2);
                        break;
                    case "L":
                        MoveLeft(individualInstruction.Item2);
                        break;
                    case "R":
                        MoveRight(individualInstruction.Item2);
                        break;
                    default:
                        throw new Exception("Error: Unknown Direction");
                }
            }

            return steps;
        }

        private List<(string, int)> ConvertToInstructions(IEnumerable<string> rawInstructions)
        {
            var result = new List<(string,int)>();
            foreach (var rawInstruction in rawInstructions)
            {
                result.Add( (rawInstruction.Substring(0,1), Convert.ToInt32(rawInstruction.Substring(1,rawInstruction.Length-1))));
            }
            return result;
        }



        public void MoveUp(int value)
        {
            for (var i = 0; i < value; i++)
            {
                CurrentY += 1;
                AddPoint();
            }
        }

        public void MoveDown(int value)
        {
            for (var i = 0; i < value; i++)
            {
                CurrentY -= 1;
                AddPoint();
            }
        }

        public void MoveLeft(int value)
        {
            for (var i = 0; i < value; i++)
            {
                CurrentX -= 1;
                AddPoint();
            }
        }

        public void MoveRight(int value)
        {
            for (var i = 0; i < value; i++)
            {
                CurrentX += 1;
                AddPoint();
            }
        }

        private void AddPoint()
        {
            if (_gridPoints.ContainsKey((CurrentX, CurrentY)))
            {
                _gridPoints[(CurrentX, CurrentY)] = "+";
                return;
            }

            _gridPoints.Add((CurrentX, CurrentY), ".");
        }


        public bool PointExists((int x, int y) point)
        {
            return _gridPoints.ContainsKey((point.x, point.y));
        }

        public Dictionary<(int, int), string> GetAllPoints()
        {
            return _gridPoints;
        }
    }
}
