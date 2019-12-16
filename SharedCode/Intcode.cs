using System;
using Utils;

namespace SharedCode
{
    public class Intcode : IIntcode
    {
        private readonly IBuffer _inputBuffer;
        private readonly IMemory _memory;
        private readonly IBuffer _outputBuffer;
        private bool _finished;
        private long _instructionPointer;
        private long _relativeBase;
        private bool _sleep;

        public int Id { get; set; }


        public Intcode(IMemory memory, IBuffer outputBuffer, IBuffer inputBuffer)
        {
            _memory = memory;
            _outputBuffer = outputBuffer;
            _inputBuffer = inputBuffer;
        }

        public bool IsRunning()
        {
            return !_finished;
        }

        public bool IsPaused()
        {
            return _sleep;
        }


        public void Wake()
        {
            _sleep = false;
        }

        public bool Stopped()
        {
            return _finished;
        }


        public void Process()
        {
            while (!_finished && !_sleep)
            {
                var instruction = new OpCodeInstruction(_memory.Get(_instructionPointer));
                var opcode = instruction.GetOpCode();
                long left;
                long right;
                long storageAddress;
                long storeValue;
                long param1;
                long param2;

                switch (instruction.GetOpCode())
                {
                    case 1: // add 
                        left = GetValue(_instructionPointer + 1, instruction.Parameter1Mode());
                        right = GetValue(_instructionPointer + 2, instruction.Parameter2Mode());

                        storeValue = left + right;
                        storageAddress = GetAddress(_instructionPointer + 3, instruction.Parameter3Mode());
                        _memory.Set(storageAddress, storeValue);
                        break;
                    case 2: // multiply

                        left = GetValue(_instructionPointer + 1, instruction.Parameter1Mode());
                        right = GetValue(_instructionPointer + 2, instruction.Parameter2Mode());
                        storeValue = left * right;

                        storageAddress = GetAddress(_instructionPointer + 3, instruction.Parameter3Mode());
                        _memory.Set(storageAddress, storeValue);

                        break;
                    case 3: // read input
                        if (_inputBuffer.IsEmpty)
                        {
                            _sleep = true;
                            break;
                        }

                        storageAddress = GetAddress(_instructionPointer + 1, instruction.Parameter1Mode());
                        _memory.Set(storageAddress, _inputBuffer.GetValue());

                        break;
                    case 4: // write output

                        var value = GetValue(_instructionPointer + 1, instruction.Parameter1Mode());
                        _outputBuffer.Add(value);

                        break;
                    case 5: // jump if true (if 1st param != 0 instruct pointer = 2nd param) other wise do nothing

                        if (GetValue(_instructionPointer + 1, instruction.Parameter1Mode()) != 0)
                        {
                            _instructionPointer = GetValue(_instructionPointer + 2, instruction.Parameter2Mode());
                            continue;
                        }

                        break;
                    case 6: // jump-if-false ( if first param == 0 set instruction pointer = 2nd param) other wise do nothing

                        if (GetValue(_instructionPointer + 1, instruction.Parameter1Mode()) == 0)
                        {
                            _instructionPointer = GetValue(_instructionPointer + 2, instruction.Parameter2Mode());
                            continue;
                        }

                        break;
                    case 7: 
                        // less-than  if 1st param < 2nd param - store 1 at 3rd param position otherwise store 0 at 3rd param position

                        param1 = GetValue(_instructionPointer + 1, instruction.Parameter1Mode());
                        param2 = GetValue(_instructionPointer + 2, instruction.Parameter2Mode());

                        storeValue = 0;
                        if (param1 < param2) storeValue = 1;

                        storageAddress = GetAddress(_instructionPointer + 3, instruction.Parameter3Mode());
                        _memory.Set(storageAddress, storeValue);

                        break;
                    case 8: 
                        // equals - if 1st param == 2nd param store 1 at 3rd param position otherwise store 0 at 3rd param position

                        param1 = GetValue(_instructionPointer + 1, instruction.Parameter1Mode());
                        param2 = GetValue(_instructionPointer + 2, instruction.Parameter2Mode());

                        storeValue = param1 == param2 ? 1 : 0;
                        storageAddress = GetAddress(_instructionPointer + 3, instruction.Parameter3Mode());
                        _memory.Set(storageAddress, storeValue);

                        break;
                    case 9: // adjust relative base

                        var move = GetValue(_instructionPointer + 1, instruction.Parameter1Mode());
                        _relativeBase += move;
                        break;

                    case 99: // end

                        _finished = true;
                        break;
                    default:
                        throw new Exception("Unknown opcode: " + instruction.GetOpCode());
                }

                if (!_sleep) IncrementInstructionPointer(instruction.GetOpCode());
            }
        }


        public string CurrentState()
        {
            return Strings.ConvertStringArrayToString(_memory.ToArray());
        }

        public string Output()
        {
            return string.Join(",", _memory.ToArray());
        }

        private void IncrementInstructionPointer(long opcode)
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
                case 9:
                    _instructionPointer += 2;
                    break;
                case 99: // stop
                    break;
                default:
                    throw new Exception("Unknown Opcode when incrementing the instruction pointer ");
            }
        }


        private long GetValue(long value, ReadMode mode)
        {
            switch (mode)
            {
                case ReadMode.Position:
                    return _memory.Get(_memory.Get(value));
                case ReadMode.Offset:
                    return _memory.Get(_relativeBase + _memory.Get(value));
                default:
                    return _memory.Get(value);
            }
        }


        private long GetAddress(long position, ReadMode mode)
        {
            switch (mode)
            {
                case ReadMode.Position:
                    return _memory.Get(position);
                case ReadMode.Offset:
                    return _memory.Get(position) + _relativeBase;
                default:
                    throw new Exception("Error: Invlid Address mode");
            }
        }
    }
}