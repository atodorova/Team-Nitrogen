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
        public void HandleInput_IsValedCommandW()
        {
            string input = "w";
            LabyrinthEngine engine = new LabyrinthEngine();
            engine.HandleInput(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HandleInput_IsValedCommandLR()
        {
            string input = "lr";
            LabyrinthEngine engine = new LabyrinthEngine();
            engine.HandleInput(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HandleInput_IsValedCommandStart()
        {
            string input = "start";
            LabyrinthEngine engine = new LabyrinthEngine();
            engine.HandleInput(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HandleInput_IsValedCommandAt()
        {
            string input = "@";
            LabyrinthEngine engine = new LabyrinthEngine();
            engine.HandleInput(input);
        }
    }
}
