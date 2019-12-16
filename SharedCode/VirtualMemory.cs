using System;
using System.Collections.Generic;
using System.Linq;

namespace SharedCode
{
    public class VirtualMemory : IMemory
    {

        private Dictionary<long, long> _memory = new Dictionary<long, long>();


        public VirtualMemory()
        {
        }

        public VirtualMemory(string states)
        {
            string[] separator = { ", ", "," };
            var initStates = states.Split(separator, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => Convert.ToInt64(x))
                .ToArray();

            var i = 0;
            foreach (var state in initStates)
            {
                _memory.Add(i, state);
                i++;
            }
        }

        public void Reset()
        {
            _memory = new Dictionary<long, long>();
        }

        public long Get(long index)
        {
            if (_memory.ContainsKey(index)) return _memory[index];

            _memory.Add(index, 0); // initialise the memory location
            return 0;
        }

        public void Set(long index, long value)
        {
            if (_memory.ContainsKey(index))
            {
                _memory[index] = value;
                return;
            }

            if (index < 0) throw new Exception("Error: Invalid Memory location"); 
            
            _memory.Add(index, value);
        }

        public long[] ToArray()
        {
            return _memory.Select( x => x.Value).ToArray();
        }
    }


}
