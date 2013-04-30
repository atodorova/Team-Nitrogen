using System;
using System.Linq;

namespace Labyrinth
{
    public class LabyrinthMatrix
    {
        private char[][] matrix;
        private int myPostionVertical;
        private int myPostionHorizontal;

        public LabyrinthMatrix()
        {
            this.myPostionHorizontal = 3;
            this.myPostionVertical = 3;
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

        public LabyrinthMatrix(LabyrinthMatrix l)
        {
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
            Random randomGenerator = new Random();
            int randomNumber = randomGenerator.Next(0, 2);
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
