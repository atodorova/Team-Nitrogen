using System;
using System.Linq;

namespace Labyrinth
{
    public class LabyrinthMatrix
    {
        public const int CENTER_X = 3;
        public const int CENTER_Y = 3;
        private char[][] matrix;
        private int myPostionVertical;
        private int myPostionHorizontal;
        private Random randomGenerator = new Random();

        public LabyrinthMatrix()
        {
            this.myPostionHorizontal = CENTER_X;
            this.myPostionVertical = CENTER_Y;
            this.matrix = new char[7][];

            for (int i = 0; i < this.matrix.Length; i++)
            {
                this.matrix[i] = new char[7];
            }

            for (int i = 0; i < this.matrix.Length; i++)
            {
                for (int j = 0; j < this.matrix[i].Length; j++)
                {
                    this.matrix[i][j] = this.GetRandomSymbol();
                }
            }

            this.matrix[3][3] = '-';
        }

        public char[][] Matrix
        {
            get
            {
                return this.matrix;
            }
        }

        public int MyPostionHorizontal
        {
            get
            {
                return this.myPostionHorizontal;
            }

            set
            {
                this.myPostionHorizontal = value;
            }
        }

        public int MyPostionVertical
        {
            get
            {
                return this.myPostionVertical;
            }

            set
            {
                this.myPostionVertical = value;
            }
        }

        private char GetRandomSymbol() 
        {
            int randomNumber = this.randomGenerator.Next(0, 2);
            if (randomNumber == 1)
            {
                return 'X';
            }
            else
            {
                return '-';
            }
        } 
    }
}
