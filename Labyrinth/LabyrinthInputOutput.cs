// -----------------------------------------------------------------------
// <copyright file="LabyrinthInputOutput.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Labyrinth
{
    using System;    
    using System.Linq;    

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class LabyrinthInputOutput
    {
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("\nWelcome to “Labirinth” game. Please try to escape. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");
        }

        public static void PrintInvalidMoveMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid move! You cannot move in that direction!");
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public static void PrintVictoryMessage(string moveCount)
        {
            Console.WriteLine("Congratulations! You escaped in " + moveCount + " moves.");
        }

        public static void PrintExitMessage()
        {
            Console.WriteLine("Good Bye!");
        }

        public static void PrintInputMessage()
        {
            Console.Write("Enter your move (L=left, R-right, U=up, D=down): ");
        }

        public static void PrintInvalidCommandMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You entered invalid command! Please, choose one of the below:");
            Console.WriteLine("R, L, U, D, Restart, Top, Exit");
            Console.ForegroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// Prints the generated game field to the console, using build-in console settings
        /// </summary>        
        public static void PrintLabyrinthMatrix(LabyrinthMatrix matrix)
        { 
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < matrix.Matrix.Length; i++)
            {
                Console.Write("\t");
                for (int j = 0; j < matrix.Matrix[i].Length; j++)
                {
                    if (i == matrix.MyPositionVertical && j == matrix.MyPositionHorizontal)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("*");
                    }
                    else
                    {
                        if (matrix.Matrix[j][i] == LabyrinthMatrix.EmptyCell)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }

                        Console.Write(matrix.Matrix[j][i]);
                    }
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.WriteLine();
        } 
    }
}
