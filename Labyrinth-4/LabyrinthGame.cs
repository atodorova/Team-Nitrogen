using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    public class LabyrinthGame
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            LabyrinthEngine processor = new LabyrinthEngine();
            while (true)
            {
                LabyrinthInputOutput.PrintLabyrinthMatrix(processor.Matrix);
                string input;
                bool isCorrectCommand = false;
                while (!isCorrectCommand)
                {
                    try
                    {
                        LabyrinthInputOutput.PrintInputMessage();
                        input = Console.ReadLine();
                        processor.HandleInput(input);
                        isCorrectCommand = true;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        LabyrinthInputOutput.PrintInvalidCommandMessage();
                    }
                }
            }
        }
    }
}
