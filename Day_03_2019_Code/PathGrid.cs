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
        private int currentSteps;
        private int stepsToDestination;
        private (int, int) _destination;

        public PathGrid()
        {
            _gridPoints = new Dictionary<(int, int), string>();
        }


        public PathGrid(string instructions)
        {
            _gridPoints = new Dictionary<(int, int), string>();
            _instructions = instructions;
            ProcessInstructions();
        }

        public int CurrentX { get; set; }
        public int CurrentY { get; set; }

        public void ProcessInstructions()
        {
            CurrentX = 0;
            CurrentY = 0;
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

        public int TraceStepsToPoint((int, int) destination)
        {
            currentSteps = 0;
            CurrentX = 0;
            CurrentY = 0;
            _destination = destination;

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

            return stepsToDestination;
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



        public void MoveUp(int value, bool trace = false)
        {
            for (var i = 0; i < value; i++)
            {
                CurrentY += 1;
                CalcSteps();
                if (!trace) AddPoint();
            }
        }

        public void MoveDown(int value, bool trace = false)
        {
            for (var i = 0; i < value; i++)
            {
                CurrentY -= 1;
                CalcSteps();
                if (!trace) AddPoint();
            }
        }

        public void MoveLeft(int value, bool trace = false)
        {
            for (var i = 0; i < value; i++)
            {
                CurrentX -= 1;
                CalcSteps();
                if (!trace) AddPoint();
            }
        }

        public void MoveRight(int value, bool trace = false)
        {
            for (var i = 0; i < value; i++)
            {
                CurrentX += 1;
                CalcSteps();
                if (!trace) AddPoint();


            }
        }

        private void CalcSteps()
        {
            currentSteps++;
            if (CurrentX == _destination.Item1 && CurrentY == _destination.Item2)
            {
                stepsToDestination = currentSteps;
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
