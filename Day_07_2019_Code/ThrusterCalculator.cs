using System.Collections.Generic;
using System.Linq;
using SharedCode;

namespace Day_07_2019_Code
{
    public class ThrusterCalculator
    {
        private Dictionary<int, IBuffer> _inputBuffers;

        public ThrusterCalculator(string input)
        {
            State = input;
            _inputBuffers = new Dictionary<int, IBuffer>();
        }

        private string State { get; }

        public long ThrustPower(IEnumerable<int> phases)
        {
            var amps = new List<Intcode>();
            _inputBuffers = new Dictionary<int, IBuffer>();
            var outPutBuffer = new SharedBuffer();

            var i = 0;
            foreach (var phase in phases)
            {
                _inputBuffers.Add(i, new InputBuffer());
                _inputBuffers[i].Add(phase);

                // var inputBuffer = InputBuffers.ContainsKey(phase - 1) ? InputBuffers[phase - 1] : InputBuffers[InputBuffers.Select(x => x.Key).Max()];

                var memory = new VirtualMemory(State);
                var amp = new Intcode(memory, outPutBuffer, _inputBuffers[i]) {Id = i};
                amps.Add(amp);
                i++;
            }

            outPutBuffer.Add(0);
            foreach (var amp in amps)
                while (amp.IsRunning())
                {
                    _inputBuffers[amp.Id].Add(outPutBuffer.GetValue());
                    amp.Process();
                }

            return outPutBuffer.GetValue();
        }


        public long ThrustPowerWithFeedBack(List<int> phases)
        {
            var input = 0;
            var amps = new List<Intcode>();
            _inputBuffers = new Dictionary<int, IBuffer>();

            var i = 0;
            foreach (var phase in phases)
            {
                _inputBuffers.Add(i, new SharedBuffer());
                _inputBuffers[i].Add(phase);
                i++;
            }

            i = 0;
            foreach (var phase in phases)
            {
                var inputBuffer = _inputBuffers.ContainsKey(i - 1) ? _inputBuffers[i - 1] : _inputBuffers[4];

                var memory = new VirtualMemory(State);
                var amp = new Intcode(memory, _inputBuffers[i], inputBuffer);
                amp.Id = phase;
                amps.Add(amp);
                i++;
            }

            _inputBuffers[0].Add(input);
            while (true)
            {
                foreach (var amp in amps)
                {
                    if (!amp.IsRunning()) continue;
                    amp.Wake();
                    amp.Process();
                }

                if (!amps.Any(x => x.IsRunning())) break;
            }

            return _inputBuffers[0].GetValue();
        }
    }
}