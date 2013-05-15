using System;
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
            Labyrinth.LabyrinthEngine engine = new Labyrinth.LabyrinthEngine();
            engine.HandleInput(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HandleInput_IsValedCommandLR()
        {
            string input = "lr";
            Labyrinth.LabyrinthEngine engine = new Labyrinth.LabyrinthEngine();
            engine.HandleInput(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HandleInput_IsValedCommandStart()
        {
            string input = "start";
            Labyrinth.LabyrinthEngine engine = new Labyrinth.LabyrinthEngine();
            engine.HandleInput(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void HandleInput_IsValedCommandAt()
        {
            string input = "@";
            Labyrinth.LabyrinthEngine engine = new Labyrinth.LabyrinthEngine();
            engine.HandleInput(input);
        }
    }
}
