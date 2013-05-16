using System;
using Labyrinth;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LabyrinthTests
{
    [TestClass]
    public class LabyrinthMatrixTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MyPositionHorisontal_ValueUnder0()
        {
            LabyrinthMatrix matrix = new LabyrinthMatrix();
            matrix.PositionHorizontal = matrix.PositionHorizontal - 7;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MyPositionVertical_ValueUnder0()
        {
            LabyrinthMatrix matrix = new LabyrinthMatrix();
            matrix.PositionVertical = matrix.PositionVertical - 7;
        }
    }
}
