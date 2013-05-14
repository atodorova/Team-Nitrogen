﻿using System;
using System.Linq;

namespace Labyrinth
{
    public class LabyrinthEngine
    {
        #region Fields

        private readonly Scoreboard scoreboard;
        private LabyrinthMatrix matrix;
        private uint moveCount;
        
        #endregion

        public LabyrinthEngine()
        {
            this.scoreboard = new Scoreboard();
            this.Restart();
            this.matrix = new LabyrinthMatrix();
            while (this.matrix.IsCorrect(this.matrix.MyPostionHorizontal, this.matrix.MyPostionVertical) == false)
            {
                this.matrix = new LabyrinthMatrix();
            }
        }

        #region Properties

        public LabyrinthMatrix Matrix
        {
            get { return this.matrix; }
            set { this.matrix = value; }
        }

        #endregion

        public void HandleInput(string input)
        {
            string lowerInput = input.ToLower();
            switch (lowerInput)
            {
                case "l":
                    if (!this.MoveLeft())
                    {
                        LabyrinthInputOutput.PrintInvalidMoveMessage();
                    }

                    break;
                case "r":
                    if (!this.MoveRight())
                    {
                        LabyrinthInputOutput.PrintInvalidMoveMessage();
                    }

                    break;
                case "u":
                    if (!this.MoveUp())
                    {
                        LabyrinthInputOutput.PrintInvalidMoveMessage();
                    }

                    break;
                case "d":
                    if (!this.MoveDown())
                    {
                        LabyrinthInputOutput.PrintInvalidMoveMessage();
                    }

                    break;
                case "top":
                    Console.WriteLine(this.scoreboard.ToString());
                    break;
                case "restart":
                    this.Restart();
                    break;
                case "exit":
                    LabyrinthInputOutput.PrintExitMessage();
                    System.Environment.Exit(0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid Command!");
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
                LabyrinthInputOutput.PrintVictoryMessage(this.moveCount.ToString());
                this.scoreboard.HandleScoreboard(this.moveCount);
                this.Restart();
            }
        }

        private void Restart()
        {
            LabyrinthInputOutput.PrintWelcomeMessage();
            this.matrix = new LabyrinthMatrix();
            this.moveCount = 0;
        }

        #region Move Methods

        private bool MoveDown()
        {
            if (this.matrix.MyPostionVertical != 6 && this.IsAvailable(0, 1))
            {
                this.matrix.MyPostionVertical++;
                this.moveCount++;
                return true;
            }

            return false;
        }

        private bool MoveUp()
        {
            if (this.matrix.MyPostionVertical != 0 && this.IsAvailable(0, -1))
            {
                this.matrix.MyPostionVertical--;
                this.moveCount++;
                return true;
            }

            return false;
        }

        private bool MoveRight()
        {
            if (this.matrix.MyPostionHorizontal != 6 && this.IsAvailable(1, 0))
            {
                this.matrix.MyPostionHorizontal++;
                this.moveCount++;
                return true;
            }

            return false;
        }

        private bool MoveLeft()
        {
            if (this.matrix.MyPostionHorizontal != 0 && this.IsAvailable(-1, 0))
            {
                this.matrix.MyPostionHorizontal--;
                this.moveCount++;
                return true;
            }

            return false;
        }
        
        private bool IsAvailable(int leftAddition, int rightAddition)
        {
            return this.matrix.Matrix[this.matrix.MyPostionHorizontal + leftAddition]
                [this.matrix.MyPostionVertical + rightAddition] == LabyrinthMatrix.EmptyCell;
        }

        #endregion
    }
}
