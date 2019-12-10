using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Utils;

namespace SharedCode
{


    public class Intcode
    {
        //  private  int[] _address;

        private long _instructionPointer;
        private long _relativeBase = 0;
        private bool _sleep;
        private bool _finished;

        private IInputBuffer _inputBuffer;
        private IOutputWriter _outputWriter;
        private IMemory _memory;
        private bool _debug;
        private int _noun = 1;
        private int _verb = 2;
        private int _ref = 3;


        public Intcode(IMemory memory, IOutputWriter outputWriter, IInputBuffer inputBuffer)
        {
            _memory = memory;
            _outputWriter = outputWriter;
            _inputBuffer = inputBuffer;
        }

        public bool IsRunning()
        {
            return !_sleep;
        }

        public bool IsPaused()
        {
            return _sleep;
        }

        public void EnableDebug()
        {
            _debug = true;
        }

        public void DisableDebug()
        {
            _debug = false;
        }
        public void Wake()
        {
            _sleep = false; ;
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

                if (_debug) Console.WriteLine("raw instruction: "+ _memory.Get(_instructionPointer));
                long left;
                long right;
                long storeAt;
                long storeValue;
                long param1;
                long param2;

                switch (instruction.GetOpCode())
                {
                    case 1: // add 
                         left = GetValue(_instructionPointer + 1, instruction.Parameter1Mode());
                         right = GetValue(_instructionPointer + 2, instruction.Parameter2Mode());
                         var m11 = instruction.Parameter1Mode();
                         var m33 = instruction.Parameter3Mode();
                        if (_debug) Console.WriteLine("Param1: " + left);
                         if (_debug) Console.WriteLine("Param2: " + right); 
                       
                         storeValue = left + right;
                         if (instruction.Parameter3Mode() == ReadMode.Position)
                         {
                             storeAt = StorageAddress(3);
                            _memory.Set(storeAt, storeValue);
                         }
                         else if (instruction.Parameter3Mode() == ReadMode.Offset)
                         {
                            storeAt = StorageAddress(3)+ _relativeBase;
                            _memory.Set(storeAt, storeValue);
                         }
                         else
                         {
                             throw new Exception("Error: Opcode 1 unknown mode");
                         }

                        break;
                    case 2: // multiply
                     
                         left = GetValue(_instructionPointer + 1, instruction.Parameter1Mode());
                         right = GetValue(_instructionPointer + 2, instruction.Parameter2Mode());
                         if (_debug) Console.WriteLine("Param1: " + left);
                         if (_debug) Console.WriteLine("Param2: " + right);
                         storeValue = left * right;
                
                         if (instruction.Parameter3Mode() == ReadMode.Position)
                         {
                             storeAt = StorageAddress(3);
                             _memory.Set(storeAt, storeValue);
                         }
                         else if (instruction.Parameter3Mode() == ReadMode.Offset)
                         {
                             storeAt = StorageAddress(3) + _relativeBase;
                             _memory.Set(storeAt, storeValue);
                         }
                         else
                         {
                             throw new Exception("Error: Opcode 2 unknown mode");
                         }

                        break;
                    case 3: // read input
                        if (_inputBuffer.IsEmpty)
                        {
                            _sleep = true;
                            break;
                        }
                        var input = _inputBuffer.GetValue();
                    
                        if (instruction.Parameter1Mode() == ReadMode.Offset)
                        {
                            var position = _memory.Get(_instructionPointer + 1 )+ _relativeBase;
                            _memory.Set(position, input);
                        }
                        else if (instruction.Parameter1Mode() == ReadMode.Immediate)
                        {
                            throw new Exception("ErrorEventArgs: Storing input");
                            _memory.Set(_memory.Get(_instructionPointer + _noun), input);
                        }
                        else
                        {
                            storeAt = _memory.Get(_instructionPointer + _noun);
                            _memory.Set(storeAt, input);
                        }

                        break;
                    case 4: // write output
                        var p = instruction.Parameter1Mode();
                        if (instruction.Parameter1Mode() == ReadMode.Position)
                        {
                            var position = _memory.Get(_instructionPointer + 1);
                            var value = _memory.Get(position);
                            _outputWriter.WriteOutput(value);
                            break;
                        }
                        else if (instruction.Parameter1Mode() == ReadMode.Immediate)
                        {
                            var value = _memory.Get(_instructionPointer + 1);
                            _outputWriter.WriteOutput(value);
                            break;
                        }

                        _outputWriter.WriteOutput(_memory.Get((_instructionPointer+1) + _relativeBase));

                        break;
                    case 5: // jump if true (if 1st param != 0 instruct pointer = 2nd param) other wise do nothing
                     
                        if (GetValue(_instructionPointer+1, instruction.Parameter1Mode()) > 0)
                        {
                            _instructionPointer = GetValue(_instructionPointer + 2, instruction.Parameter2Mode());
                            continue;
                        }
                        break;
                    case 6: // jump-if-false ( if first param == 0 set instruction pointer = 2nd param) other wise do nothing
                        
                        if (_memory.Get(StorageAddress(1)) == 0)
                        {
                            _instructionPointer = GetValue(_instructionPointer + 2, instruction.Parameter2Mode());
                            continue;
                        }
                        break;
                    case 7: // less-than  if 1st param < 2nd param - store 1 at 3rd param position otherwise store 0 at 3rd param position

                        param1 = GetValue(_instructionPointer + 1, instruction.Parameter1Mode());
                        param2 = GetValue(_instructionPointer + 2, instruction.Parameter2Mode());
                   
                        storeValue =   0;
                        if (param1 < param2) storeValue = 1;

                        if (instruction.Parameter3Mode() == ReadMode.Position)
                        {
                            storeAt = StorageAddress(3);
                            _memory.Set(storeAt, storeValue);
                        }
                        else if (instruction.Parameter3Mode() == ReadMode.Offset)
                        {
                            storeAt = _memory.Get(StorageAddress(3) + _relativeBase);
                            _memory.Set(storeAt, storeValue);
                        }
                        else
                        {
                            throw new Exception("Error: Opcode 7 unknown mode");
                        }


                        break;
                    case 8: // equals - if 1st param == 2nd param store 1 at 3rd param position otherwise store 0 at 3rd param position
                        
                        param1 = GetValue(_instructionPointer + 1, instruction.Parameter1Mode());
                        param2 = GetValue(_instructionPointer + 2, instruction.Parameter2Mode());

                        storeValue = param1 == param2 ? 1 : 0;
                        if (instruction.Parameter3Mode() == ReadMode.Position)
                        {
                            storeAt = StorageAddress(3);
                            _memory.Set(storeAt, storeValue);
                        }
                        else if (instruction.Parameter3Mode() == ReadMode.Offset)
                        {
                            storeAt = StorageAddress(3) + _relativeBase;
                            _memory.Set(storeAt, storeValue);
                        }
                        else
                        {
                            throw new Exception("Error: Opcode 8 unknown mode");
                        }
                   
                        break;
                    case 9: // adjust relative base
                      
                        var move = GetValue(_instructionPointer + 1, instruction.Parameter1Mode());
                        Console.WriteLine("OpCode:9 Mode:"+ instruction.Parameter1Mode());
                        Console.WriteLine("relativeBase(" + _relativeBase + ")+move(" + move + ") = " + ( _relativeBase + move));
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

        public void IncrementInstructionPointer(long opcode)
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
                    break;
            }
        }

        public long StorageAddress(long offset)
        {
            return _memory.Get(_instructionPointer + offset);
        }

        public long GetValue(long value, ReadMode mode)
        {
            if (mode == ReadMode.Position)
            {
                return _memory.Get(_memory.Get(value));
            }

            if (mode == ReadMode.Offset)
            {
                return _memory.Get(_relativeBase + _memory.Get(value));
            }

            return _memory.Get(value);
        }

     


    }
}
