using System;
using System.Linq;
using Day_11_2019_Code;
using SharedCode;
using SharedCode.Robots;

namespace Day_11_2019_Console
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
          //  inputBuffer.Add(1);
            var memory = new VirtualMemory(state.First());
            var computer = new Intcode(memory, outputBuffer, inputBuffer);

            var robot = new Robot(computer, outputBuffer, inputBuffer);
            var spaceShip = new SpaceShipHull();
            var spaceShipPainter = new SpaceShipPainter(robot, spaceShip);
            spaceShipPainter.PaintHull();

            var spaceshipVisualiser = new SpaceShipVisualiser(spaceShip);
            var hullAsStrings = spaceshipVisualiser.Draw();

            var decodeImgLines = hullAsStrings.Split('E');


            foreach(var line in decodeImgLines)
            {
                Console.WriteLine(line);
            }
                

            Console.WriteLine("Number of Painted Panels:" + spaceShip.GetNumberOfPaintedPanels());


            Console.WriteLine("Part 2");

             outputBuffer = new OutputBufferQueue();
             inputBuffer = new InputBuffer();
             memory = new VirtualMemory(state.First());
             computer = new Intcode(memory, outputBuffer, inputBuffer);

             robot = new Robot(computer, outputBuffer, inputBuffer);
             spaceShip = new SpaceShipHull();
             spaceShip.PaintSquare((0,0), PaintColour.White);
             spaceShipPainter = new SpaceShipPainter(robot, spaceShip);
         
             spaceShipPainter.PaintHull();

             spaceshipVisualiser = new SpaceShipVisualiser(spaceShip);
             hullAsStrings = spaceshipVisualiser.Draw();

             decodeImgLines = hullAsStrings.Split('E');


            foreach(var line in decodeImgLines)
            {
                Console.WriteLine(line);
            }



            Console.WriteLine("Press Enter to Continue!");
            Console.ReadLine();
        }
    }
}
