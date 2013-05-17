using System;
using Labyrinth;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace LabyrinthTests
{
    [TestClass]
    public class ScoreboardTest
    {
        [TestMethod]
        public void Scoreboard_HandleScoreboardOneName()
        {
            Scoreboard sb = new Scoreboard();
            string result = sb.HandleScoreboard(7, "Gosho");
            string expectedResult = "1. Gosho --> 7 moves.\r\n";
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Scoreboard_HandleScoreboardThreeoNames()
        {
            Scoreboard sb = new Scoreboard();
            string result = sb.HandleScoreboard(7, "Gosho");
            result = sb.HandleScoreboard(3, "Pesho");
            result = sb.HandleScoreboard(5, "Ivan");
            string expectedResult = "1. Pesho --> 3 moves.\r\n" +
                "2. Ivan --> 5 moves.\r\n3. Gosho --> 7 moves.\r\n";
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Scoreboard_HandleScoreboardSixoNames()
        {
            Scoreboard sb = new Scoreboard();
            string result = sb.HandleScoreboard(7, "Gosho");
            result = sb.HandleScoreboard(3, "Pesho");
            result = sb.HandleScoreboard(5, "Ivan");
            result = sb.HandleScoreboard(2, "Mimi");
            result = sb.HandleScoreboard(6, "Rosen");
            result = sb.HandleScoreboard(10, "Bobi");
            string expectedResult = "Your not good enough for the scoreboard :)\r\n";
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Scoreboard_ToStringEmptyScoreboard()
        {
            Scoreboard sb = new Scoreboard();
            string result = sb.ToString();
            string expectedResult = "The scoreboard is empty.\r\n";
            Assert.AreEqual(result, expectedResult);
        }

        [TestMethod]
        public void Scoreboard_Getlist()
        {
            Scoreboard sb = new Scoreboard();
            string result = sb.HandleScoreboard(7, "Gosho");
            Assert.AreEqual("Gosho", sb.ScoreboardList[0].Item2);
        }
    }
}
