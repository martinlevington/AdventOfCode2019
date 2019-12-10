using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Day_05_2019_Code;

namespace Day_07_2019_Code
{
    public class ThrusterCalculator
    {

      
        public static Dictionary<int, Queue<int>> SharedMemory;

    
        public ThrusterCalculator(string input)
        {
            _state = input;
            SharedMemory = new Dictionary<int, Queue<int>>();
        }

        private string _state { get; }

        public int ThrustPower(List<int> phases)
        {
           
            var amps = new List<Intcode>();
            var sharedMemory = new Queue<int>();

            foreach (var phase in phases)
            {
                var instructions = new Queue<int>();
                instructions.Enqueue(phase);
          
                var amp = new Intcode(_state, instructions);
                amp.SetOutputMemory(sharedMemory);
                amps.Add(amp);
              
            }

            sharedMemory.Enqueue(0);
            foreach (var amp in amps)
            {
                amp.AddInstruction(sharedMemory.Dequeue());
                amp.Process();
            }

            return sharedMemory.Dequeue();
        }

        

        public int ThrustPowerWithFeedBack(List<int> phases)
        {
           
            var input = 0;
            var amps = new List<Intcode>();

            var i = 0;
            foreach (var phase in phases)
            {
                SharedMemory.Add(i, new Queue<int>());
                SharedMemory[i].Enqueue(phase);

                var amp = new Intcode(_state, SharedMemory[i]);
                amp.ID = i;

                amps.Add(amp);
                i++;
            }

            // config amps
            amps[0].SetOutputMemory(SharedMemory[1]);
            amps[1].SetOutputMemory(SharedMemory[2]);
            amps[2].SetOutputMemory(SharedMemory[3]);
            amps[3].SetOutputMemory(SharedMemory[4]);
            amps[4].SetOutputMemory(SharedMemory[0]);

    

            // default input 0
            SharedMemory[0].Enqueue(input);
            while (true)
            {

                foreach (var amp in amps)
                {

                    if (amp.IsRunning)
                    {
                        amp.Sleep = false;
                        amp.Process();
                    }

                }

                if (!amps.Any(x => x.IsRunning == true))
                {
                    break;
                }
            }

            return amps[4].Output();
        }
    }
}
