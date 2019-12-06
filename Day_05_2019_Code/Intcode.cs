using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Day_05_2019_Code
{



    public class Intcode
    {
        private readonly int[] _address;
        private int _instructionPointer;
        private List<int> _output;


        public Intcode(string input)
        {
            string[] separator = { ", ", "," };
            _address = input.Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToInt32(x))
                .ToArray();
            _output = new List<int>();
        }

        public void Process(int input)
        {
            while (_address[_instructionPointer] != 99)
            {

         
                var instruction = new OpCodeInstruction(_address[_instructionPointer]);
                switch (instruction.GetOpCode())
                {
                    case 1:
                        _address[StorageAddress(3)] = CalculateValues(
                            GetValue(Noun(),instruction.IsPositionMode('C')), 
                                GetValue(Verb(), instruction.IsPositionMode('B')) ,
                                instruction.GetOpCode() );
                        break;
                    case 2:
                        var storeAt = StorageAddress(3);
                        var left = GetValue(Noun(), instruction.IsPositionMode('C'));
                        var right = GetValue(Verb(), instruction.IsPositionMode('B'));

                        _address[storeAt] = CalculateValues(
                            GetValue(Noun(), instruction.IsPositionMode('C')),
                            GetValue(Verb(), instruction.IsPositionMode('B')),
                            instruction.GetOpCode());
                        break;
                    case 3:
                        _address[StorageAddress(1)] = input ;
                        break;
                    case 4:
                        _output.Add(GetValue(StorageAddress(1), instruction.IsPositionMode('C')));
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
                    default: 
                        throw new Exception("Unknown opcode: "+ instruction.GetOpCode());
                }
                IncrementInstructionPointer(instruction.GetOpCode());


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

        public string Output()
        {
            return string.Join(",", _output);
        }

        public void IncrementInstructionPointer(int opcode)
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

        public int StorageAddress(int offset)
        {
            return _address[_instructionPointer + offset];
        }

        public int GetValue(int address, bool positionMode)
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
