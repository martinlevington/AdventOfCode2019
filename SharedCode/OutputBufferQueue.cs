using System.Collections.Generic;
using System.Linq;

namespace SharedCode
{
    public class OutputBufferQueue : IBuffer
    {
        private Queue<long> _buffer= new Queue<long>();


        public int Count => _buffer.Count;
        public bool IsEmpty => !_buffer.Any();

        public void Add(long value)
        {
            _buffer.Enqueue(value);
        }

        public long GetValue()
        {
           return  _buffer.Dequeue();
        }

        public override string ToString()
        {
            return string.Join(",",_buffer.ToArray());
        }
    }
}
