using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Day_07_2019_Code
{
    public class IntcodeV2
    {
        private int[] _address;
        private readonly int[] _initalState;
        private readonly Queue<int> _inputMemory;
        private int _instructionPointer;
        private int _lastOutput;
        private Queue<int> _outputMemory;
        public bool IsRunning = true;


        public IntcodeV2(string input, Queue<int> inputMemory)
        {
            string[] separator = {", ", ","};
            _address = input.Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x))
                .ToArray();
            _initalState = _address;
            _inputMemory = inputMemory == null ? new Queue<int>() : inputMemory;
            _outputMemory = new Queue<int>();
            Sleep = false;
        }

        public int Id { get; set; }


        public bool Sleep { get; set; }

        public void SetOutputMemory(Queue<int> outputMemory)
        {
            _outputMemory = outputMemory;
        }

        public void AddInstruction(int instuction)
        {
            _inputMemory.Enqueue(instuction);
        }

        public bool ResetMemory()
        {
            _address = _initalState;
            return true;
        }

        public bool ResetPointer()
        {
            _instructionPointer = 0;
            return true;
        }

        public void Process()
        {
            while (IsRunning && !Sleep)
            {
                var instruction = new OpCodeInstruction(_address[_instructionPointer]);
                switch (instruction.GetOpCode())
                {
                    case 1:
                        _address[StorageAddress(3)] = CalculateValues(
                            GetValue(Noun(), instruction.IsPositionMode('C')),
                            GetValue(Verb(), instruction.IsPositionMode('B')),
                            instruction.GetOpCode());
                        break;
                    case 2:
                        var storeAt = StorageAddress(3);

                        _address[storeAt] = CalculateValues(
                            GetValue(Noun(), instruction.IsPositionMode('C')),
                            GetValue(Verb(), instruction.IsPositionMode('B')),
                            instruction.GetOpCode());
                        break;
                    case 3:
                        if (!_inputMemory.Any())
                        {
                            Sleep = true;
                            break;
                        }

                        _address[StorageAddress(1)] = _inputMemory.Dequeue();
                        // Console.WriteLine("Computer: " + ID + " Read in value: " + _address[StorageAddress(1)]);
                        break;
                    case 4:
                        // Console.WriteLine("Computer: "+ ID + " storing: " + GetValue(StorageAddress(1), instruction.IsPositionMode('C')) + " in output memory");
                        _outputMemory.Enqueue(GetValue(StorageAddress(1), instruction.IsPositionMode('C')));
                        _lastOutput = GetValue(StorageAddress(1), instruction.IsPositionMode('C'));

                        break;
                    case 5:

                        if (GetValue(StorageAddress(1), instruction.IsPositionMode('C')) > 0)
                        {
                            _instructionPointer = GetValue(StorageAddress(2), instruction.IsPositionMode('B'));
                            continue;
                        }

                        break;
                    case 6:
                        if (GetValue(StorageAddress(1), instruction.IsPositionMode('C')) == 0)
                        {
                            _instructionPointer = GetValue(StorageAddress(2), instruction.IsPositionMode('B'));
                            continue;
                        }

                        break;
                    case 7:
                        _address[StorageAddress(3)] = CalculateValues(
                            GetValue(Noun(), instruction.IsPositionMode('C')),
                            GetValue(Verb(), instruction.IsPositionMode('B')),
                            instruction.GetOpCode());
                        break;
                    case 8:
                        _address[StorageAddress(3)] = CalculateValues(
                            GetValue(Noun(), instruction.IsPositionMode('C')),
                            GetValue(Verb(), instruction.IsPositionMode('B')),
                            instruction.GetOpCode());
                        break;
                    case 99:
                        IsRunning = false;
                        break;
                    default:
                        throw new Exception("Unknown opcode: " + instruction.GetOpCode());
                }

                if (!Sleep)
                {
                    IncrementInstructionPointer(instruction.GetOpCode());
                }
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

        public string OutputResults()
        {
            return string.Join(",", _outputMemory);
        }

        public int Output()
        {
            return _lastOutput;
        }

        private void IncrementInstructionPointer(int opcode)
        {
            switch (opcode)
            {
                case 1: // add
                    _instructionPointer += 4;
                    break;
                case 2: // multiply
                    _instructionPointer += 4;
                    break;
                case 3: // save
                    _instructionPointer += 2;
                    break;
                case 4: // output
                    _instructionPointer += 2;
                    break;
                case 5:
                case 6:
                    _instructionPointer += 3;
                    break;
                case 7:
                    _instructionPointer += 4;
                    break;
                case 8:
                    _instructionPointer += 4;
                    break;
                case 99: // stop
                    break;
                default:
                    throw new Exception("Unknown Opcode when incrementing the instruction pointer ");
                    break;
            }
        }

        private int StorageAddress(int offset)
        {
            return _address[_instructionPointer + offset];
        }

        private int GetValue(int address, bool positionMode)
        {
            if (positionMode)
            {
                return _address[address];
            }

            return address;
        }

        private int Noun()
        {
            return _address[_instructionPointer + 1];
        }

        private int Verb()
        {
            return _address[_instructionPointer + 2];
        }

        private int CalculateValues(int left, int right, int opcode)
        {
            switch (opcode)
            {
                case 1:
                    return left + right;
                case 2:
                    return left * right;
                case 7:
                    return Convert.ToInt32(left < right);
                case 8:
                    return Convert.ToInt32(left == right);
                default:
                    throw new Exception("Unknown opcode");
            }
        }
    }
}