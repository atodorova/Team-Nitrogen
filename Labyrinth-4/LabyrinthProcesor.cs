using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    public class LabyrinthProcesor
    {
        #region Fields

        private LabyrinthMatrix matrix;
        private uint moveCount;
        private Top5Scoreboard scoreboard;

        #endregion

        #region Properties

        public LabyrinthProcesor()
        {
            this.scoreboard = new Top5Scoreboard();
            this.Restart();
        }

        public LabyrinthMatrix Matrix
        {
            get { return this.matrix; }
            set { this.matrix = value; }
        }

        #endregion

        public void ShowInputMessage()
        {
            Console.Write("Enter your move (L=left, R-right, U=up, D=down): ");
        }

        public void HandleInput(string input)
        {
            string lowerInput = input.ToLower();
            switch (lowerInput)
            {
                case "l":
                    if (!this.MoveLeft())
                    {
                        Console.WriteLine("Invalid move!");
                    }

                    break;
                case "r":
                    if (!this.MoveRight())
                    {
                        Console.WriteLine("Invalid move!");
                    }

                    break;
                case "u":
                    if (!this.MoveUp())
                    {
                        Console.WriteLine("Invalid move!");
                    }

                    break;
                case "d":
                    if (!this.MoveDown())
                    {
                        Console.WriteLine("Invalid move!");
                    }

                    break;
                case "top":
                    this.scoreboard.ShowScoreboard();
                    break;
                case "restart":
                    this.Restart();
                    break;
                case "exit":
                    Console.WriteLine("Good bye!");
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid command!");
                    break;
            }

            this.IsFinished();
        }

        private void IsFinished()
        {
            if (this.matrix.MyPostionHorizontal == 0 ||
                this.matrix.MyPostionHorizontal == 6 ||
                this.matrix.MyPostionVertical == 0 ||
                this.matrix.MyPostionVertical == 6)
            {
                Console.WriteLine("Congratulations! You escaped in " + this.moveCount.ToString() + " moves.");
                this.scoreboard.HandleScoreboard(this.moveCount);
                this.Restart();
            }
        }

        private void Restart()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to “Labirinth” game. Please try to escape. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.");

            this.matrix = new LabyrinthMatrix();
            this.moveCount = 0;
        }

        #region Move Methods

        private bool MoveDown()
        {
            if (!(this.matrix.MyPostionVertical == 6) &&
                this.matrix.Matrix[this.matrix.MyPostionHorizontal][this.matrix.MyPostionVertical + 1] == '-')
            {
                this.matrix.MyPostionVertical++;
                this.moveCount++;
                return true;
            }

            return false;
        }

        private bool MoveUp()
        {
            if (!(this.matrix.MyPostionVertical == 0) &&
                this.matrix.Matrix[this.matrix.MyPostionHorizontal][this.matrix.MyPostionVertical - 1] == '-')
            {
                this.matrix.MyPostionVertical--;
                this.moveCount++;
                return true;
            }

            return false;
        }

        private bool MoveRight()
        {
            if (!(this.matrix.MyPostionHorizontal == 6) &&
                 this.matrix.Matrix[this.matrix.MyPostionHorizontal + 1][this.matrix.MyPostionVertical] == '-')
            {
                this.matrix.MyPostionHorizontal++;
                this.moveCount++;
                return true;
            }

            return false;
        }

        private bool MoveLeft()
        {
            if (!(this.matrix.MyPostionHorizontal == 0) &&
                this.matrix.Matrix[this.matrix.MyPostionHorizontal - 1][this.matrix.MyPostionVertical] == '-')
            {
                this.matrix.MyPostionHorizontal--;
                this.moveCount++;
                return true;
            }

            return false;
        }

        #endregion
    }
}
