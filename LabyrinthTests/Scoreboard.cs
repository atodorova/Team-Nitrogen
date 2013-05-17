using System;
using Labyrinth;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LabyrinthTests
{
    [TestClass]
    public class Scoreboard
    {
        [TestMethod]
        public void Scoreboard_ToString()
        {
            Scoreboard sb = new Scoreboard();
            sb.ToString();
        }
    }
}
