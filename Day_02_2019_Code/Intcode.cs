using System;
using System.Linq;
using Utils;

namespace Day_02_2019_Code
{
    public class Intcode
    {
        private readonly int[] _address;
        private int _instructionPointer;

        public Intcode(string input)
        {
            string[] separator = {", ", ","};
            _address = input.Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x))
                .ToArray();
        }

        public void Process()
        {
            while (_address[_instructionPointer] != 99)
            {
                var s = StorageAddress();
                _address[StorageAddress()] = CalculateValues(Noun(), Verb(), Opcode());
                IncrementInstructionPointer(Opcode());
            }
        }

        public void UpdateInput(int position, int value)
        {
            _address[position] = value;
        }

        public string Result()
        {
            return Strings.ConvertStringArrayToString(_address);
        }

        public int Output()
        {
            return _address[0];
        }

        public void IncrementInstructionPointer(int opcode)
        {
            _instructionPointer += 4;
        }

        public int StorageAddress()
        {
            return _address[_instructionPointer + 3];
        }

        private int Opcode()
        {
            return _address[_instructionPointer];
        }

        private int Noun()
        {
            return _address[_instructionPointer + 1];
        }

        private int Verb()
        {
            return _address[_instructionPointer + 2];
        }

        private int CalculateValues(int noun, int verb, int opcode)
        {
            switch (opcode)
            {
                case 1:
                    return _address[noun] + _address[verb];
                case 2:
                    return _address[noun] * _address[verb];
                default:
                    throw new Exception("Unknown opcode");
            }
        }
    }
}