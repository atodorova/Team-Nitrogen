using System;
using System.Linq;

namespace Labyrinth
{   
    public class LabyrinthEngine
    {
        #region Fields

        private readonly Scoreboard scoreboard;
        private readonly int matrixMaxPosition;
        private LabyrinthMatrix matrix;
        private uint moveCount;        
        
        #endregion

        /// <summary>
        /// Constructor, used for initializing the game's scoreboard and the matrix/labyrinth.
        /// </summary>
        public LabyrinthEngine()
        {
            this.scoreboard = new Scoreboard();
            this.matrixMaxPosition = LabyrinthMatrix.MatrixSize - 1;
            this.Restart();            
        }

        #region Properties

        public LabyrinthMatrix Matrix
        {
            get { return this.matrix; }            
        }

        #endregion

        public LabyrinthMatrix LabyrinthMatrix
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Scoreboard Scoreboard
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        /// <summary>
        /// Handles all possible correct inputs. If input is not correct throws exception.
        /// </summary>
        /// <param name="input">Command, used for controlling the game.</param>
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
        //Private methods
        private void IsFinished()
        {
            int currentHorizontalPos = this.matrix.PositionHorizontal;
            bool validHorizontalEnd = (currentHorizontalPos == 0) || (currentHorizontalPos == this.matrixMaxPosition);
            int currentVerticalPos = this.matrix.PositionVertical;
            bool validVerticalEnd = (currentVerticalPos == 0) || (currentVerticalPos == this.matrixMaxPosition);

            if (validHorizontalEnd || validVerticalEnd)
            {
                LabyrinthInputOutput.PrintVictoryMessage(this.moveCount.ToString());
                Console.WriteLine(this.scoreboard.HandleScoreboard(this.moveCount, LabyrinthInputOutput.GetNameForScoreboard()));
                this.Restart();
            }
        }

        private void Restart()
        {
            LabyrinthInputOutput.PrintWelcomeMessage();
            this.matrix = new LabyrinthMatrix();
            this.moveCount = 0;

            while (!this.matrix.IsCorrect())
            {
                this.matrix = new LabyrinthMatrix();
            }           
        }

        #region Move Methods

        private bool MoveDown()
        {
            if (this.matrix.PositionVertical != this.matrixMaxPosition && this.IsAvailable(0, 1))
            {
                this.matrix.PositionVertical++;
                this.moveCount++;
                return true;
            }

            return false;
        }

        private bool MoveUp()
        {
            if (this.matrix.PositionVertical != 0 && this.IsAvailable(0, -1))
            {
                this.matrix.PositionVertical--;
                this.moveCount++;
                return true;
            }

            return false;
        }

        private bool MoveRight()
        {
            if (this.matrix.PositionHorizontal != this.matrixMaxPosition && this.IsAvailable(1, 0))
            {
                this.matrix.PositionHorizontal++;
                this.moveCount++;
                return true;
            }

            return false;
        }

        private bool MoveLeft()
        {
            if (this.matrix.PositionHorizontal != 0 && this.IsAvailable(-1, 0))
            {
                this.matrix.PositionHorizontal--;
                this.moveCount++;
                return true;
            }

            return false;
        }
        
        private bool IsAvailable(int leftAddition, int rightAddition)
        {
            var nextPosition = this.matrix.Matrix[this.matrix.PositionHorizontal + leftAddition][this.matrix.PositionVertical + rightAddition];
            return nextPosition == LabyrinthMatrix.EmptyCell;
        }

        #endregion
    }
}
