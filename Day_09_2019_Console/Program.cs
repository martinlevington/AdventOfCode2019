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

            Console.WriteLine("Running In Test Mode((1)");

            var writer = new OutputWriterQueue();
            var inputBuffer = new InputBuffer();
            inputBuffer.Add(1);
            var memory = new VirtualMemory(state.First());
            var computer = new Intcode(memory, writer, inputBuffer);
            computer.EnableDebug();
         

            computer.Process();
            var output = writer.ToString();

            Console.WriteLine("Result: " + output);
            Console.ReadLine();
          
        }
    }
}
