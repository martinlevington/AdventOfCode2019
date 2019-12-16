using System.Collections.Generic;

namespace SharedCode
{
    public class SharedBuffer : IBuffer
    {
        private readonly object _queueLock = new object();

        private readonly Queue<long> _buffer = new Queue<long>();
        public int Count
        {
            get {
                lock (_queueLock)
                {
                    return _buffer.Count;
                }
            }
        }

        public bool IsEmpty
        {
            get {
                lock (_queueLock)
                {
                    return _buffer.Count == 0;
                }
            }
        }

        public void Add(long value)
        {
            lock (_queueLock)
            {
                _buffer.Enqueue(value);
            }
        }

        public long GetValue()
        {
            lock (_queueLock)
            {
                return _buffer.Dequeue();
            }
        }


        public override string ToString()
        {
            lock (_queueLock)
            {
                return string.Join(",", _buffer.ToArray());
            }
        }
    }
}