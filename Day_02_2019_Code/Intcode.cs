using System;
using System.Linq;
using Utils;

namespace Day_02_2019_Code
{
    public class Intcode
    {
        private  int[] _input;

        public Intcode(string input)
        {
            string[] separator = { ", ", "," };
            _input = input.Split(separator,StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x)).ToArray();

        }

        public void Process()
        {
            var current = 0;
            while (_input[current] != 99)
            {
                switch (_input[current])
                {
                    case 1:
                        AddValues(current);
                        current = current + 4;
                        break;
                    case 2:
                        MultiplyValues(current);
                        current = current + 4;
                        break;
                    default:
                        throw new Exception("Unknown instruction");
                }
            }
        }

        public void UpdateInput(int position, int value)
        {
            _input[position] = value;
        }

        public string Result()
        {
            return Strings.ConvertStringArrayToString(_input);
        }

        private void AddValues(int current)
        {
            _input[_input[current + 3]] = _input[_input[current + 1]] + _input[_input[current + 2]];

        }

        private void MultiplyValues(int current)
        {
            _input[_input[current + 3]] = _input[_input[current + 1]] * _input[_input[current + 2]];
        }
    }
}
