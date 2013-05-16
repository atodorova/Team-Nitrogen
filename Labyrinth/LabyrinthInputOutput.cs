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
    /// Class for printing game elements and messages to the console
    /// </summary>
    public static class LabyrinthInputOutput
    {
        public static string PrintWelcomeMessage()
        {
            return "\nWelcome to “Labirinth” game. Please try to escape. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.";
        }

        public static string PrintInvalidMoveMessage()
        {
            
            return "Invalid move! You cannot move in that direction!";
            
        }

        public static string PrintVictoryMessage(string moveCount)
        {
            return "Congratulations! You escaped in " + moveCount + " moves.";
        }

        public static string PrintExitMessage()
        {
            return "Good Bye!";
        }

        public static string PrintInputMessage()
        {
            return "Enter your move (L=left, R-right, U=up, D=down): ";
        }

        public static string PrintInvalidCommandMessage()
        {
            
            return "You entered invalid command! Please, choose one of the below:\n" + 
            "R, L, U, D, Restart, Top, Exit";
            
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
                    if (i == matrix.PositionVertical && j == matrix.PositionHorizontal)
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
