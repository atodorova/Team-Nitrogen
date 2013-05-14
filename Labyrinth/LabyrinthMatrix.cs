using System;
using System.Linq;
using System.Threading;

namespace Labyrinth
{
    public class LabyrinthMatrix
    {
        public const int CenterX = 3;
        public const int CenterY = 3;
        public const int MatrixSize = 7;
        public const char EmptyCell = '-';
        public const char WallCell = 'X';
        private readonly bool[,] checkCell;
        private readonly Random randomGenerator;
        private char[][] matrix;
        private int myPostionVertical;
        private int myPostionHorizontal;
        
        public LabyrinthMatrix()
        {
            this.randomGenerator = new Random();
            this.checkCell = new bool[MatrixSize, MatrixSize];
            this.MyPositionHorizontal = CenterX;
            this.MyPositionVertical = CenterY;
            this.GenerateMatrix();
        }

        public char[][] Matrix
        {
            get
            {
                return this.matrix;
            }
        }

        public int MyPositionHorizontal
        {
            get
            {
                return this.myPostionHorizontal;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("myPositionHorizontal", "The position cannot be a negative number");
                }
                this.myPostionHorizontal = value;
            }
        }

        public int MyPositionVertical
        {
            get
            {
                return this.myPostionVertical;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("myPositionVertical", "The position cannot be a negative number");
                }
                this.myPostionVertical = value;
            }
        }

        public bool IsCorrect(int row, int col)
        {
            if (row < 0 || col < 0 || row >= MatrixSize || col >= MatrixSize)
            {
                return true;
            }

            if (this.checkCell[row, col] == true)
            {
                return false;
            }

            if (this.matrix[row][col] == EmptyCell)
            {
                this.checkCell[row, col] = true;
                return this.IsCorrect(row - 1, col) || this.IsCorrect(row, col - 1) || this.IsCorrect(row, col + 1)
                    || this.IsCorrect(row + 1, col);
            }
            else
            {
                return false;
            }
        }

        private void GenerateMatrix()
        {
            this.matrix = new char[MatrixSize][];
            for (int i = 0; i < MatrixSize; i++)
            {
                this.matrix[i] = new char[MatrixSize];
            }

            for (int i = 0; i < MatrixSize; i++)
            {
                for (int j = 0; j < MatrixSize; j++)
                {
                    this.matrix[i][j] = this.GetRandomSymbol();
                }
            }

            this.matrix[CenterX][CenterY] = EmptyCell;
        }

        private char GetRandomSymbol() 
        {
            int randomNumber = this.randomGenerator.Next(0, 2);
            if (randomNumber == 1)
            {
                return WallCell;
            }
            else
            {
                return EmptyCell;
            }
        } 
    }
}
