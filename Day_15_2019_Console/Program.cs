using System;
using System.Linq;
using Day_15_2019_Code;
using SharedCode;
using SharedCode.Robots;

namespace Day_15_2019_Console
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Starting Up!");

            string[] state = System.IO.File.ReadAllLines(@"input.txt");

            Console.WriteLine("Part 1");

            var outputBuffer = new OutputBufferQueue();
            var inputBuffer = new InputBuffer();
            var memory = new VirtualMemory(state.First());
            var computer = new Intcode(memory, outputBuffer, inputBuffer);

            var robot = new Robot(computer, outputBuffer, inputBuffer);
            var maze = new Area();

            var areaTextVisualiser = new AreaTextVisualiser(maze);
            var solver = new MazeSolver(robot, maze,areaTextVisualiser );
            var shortestPath = solver.Solve((0,0));

          
            Console.WriteLine("Shortest Path: "+ shortestPath);



           

        }
    }
}
