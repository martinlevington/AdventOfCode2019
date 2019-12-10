using System;
using System.Collections.Generic;
using System.Text;

namespace SharedCode
{
    public class InputBuffer : IInputBuffer
    {
        private Queue<long> _inputMemory = new Queue<long>();

        public void Add(long value)
        {
            _inputMemory.Enqueue(value);
        }

        public long GetValue()
        {
            return _inputMemory.Dequeue();
        }

        public int Count => _inputMemory.Count;

        public bool IsEmpty => _inputMemory.Count == 0;

    }
}
