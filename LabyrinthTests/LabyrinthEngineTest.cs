using System;
using Labyrinth;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LabyrinthTests
{
    [TestClass]
    public class LabyrinthEngineTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HandleInput_IsValidCommandW()
        {
            string input = "w";
            LabyrinthEngine engine = new LabyrinthEngine();
            engine.HandleInput(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HandleInput_IsValidCommandLR()
        {
            string input = "lr";
            LabyrinthEngine engine = new LabyrinthEngine();
            engine.HandleInput(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HandleInput_IsValidCommandStart()
        {
            string input = "start";
            LabyrinthEngine engine = new LabyrinthEngine();
            engine.HandleInput(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HandleInput_IsValidCommandAt()
        {
            string input = "@";
            LabyrinthEngine engine = new LabyrinthEngine();
            engine.HandleInput(input);
        }
    }
}
