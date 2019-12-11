using SharedCode;
using System;
using System.Linq;

namespace Day_09_2019_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] state = System.IO.File.ReadAllLines(@"input.txt");

            Console.WriteLine("Running In Test Mode(1)");

            var writer = new OutputBufferQueue();
            var inputBuffer = new InputBuffer();
            inputBuffer.Add(1);
            var memory = new VirtualMemory(state.First());
            var computer = new Intcode(memory, writer, inputBuffer);


            computer.Process();
            var output = writer.ToString();

            Console.WriteLine("Result: " + output);

            Console.WriteLine("Running In Test Mode(2)");

             writer = new OutputBufferQueue();
             inputBuffer = new InputBuffer();
            inputBuffer.Add(2);
             memory = new VirtualMemory(state.First());
             computer = new Intcode(memory, writer, inputBuffer);


            computer.Process();
             output = writer.ToString();

            Console.WriteLine("Result: " + output);

            Console.WriteLine("Press Enter to Continue: ");
            Console.ReadLine();
          
        }
    }
}
