using System;
using System.Collections.Generic;
using System.Text;

namespace SharedCode
{
    public class OutputWriterQueue : IOutputWriter
    {
        private Queue<long> _buffer= new Queue<long>();



        public void WriteOutput(long value)
        {
            _buffer.Enqueue(value);
        }

        public override string ToString()
        {
            return string.Join(",",_buffer.ToArray());
        }
    }
}
