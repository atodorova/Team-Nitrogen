using System;
using Labyrinth;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LabyrinthTests
{
    [TestClass]
    public class LabyrinthInputOutputTest
    {
        [TestMethod]
        public void PrintExitMessage()
        {
            var currentConsoleOut = Console.Out;

            string message = "Good Bye!\r\n";

            using (var consoleOutput = new ConsoleOutput())
            {
                LabyrinthInputOutput.PrintExitMessage();

                Assert.AreEqual(message, consoleOutput.GetOuput());
            }

            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void PrintInvalidMoveMessage()
        {
            var currentConsoleOut = Console.Out;

            string message = "Invalid move! You cannot move in that direction!\r\n";

            using (var consoleOutput = new ConsoleOutput())
            {
                LabyrinthInputOutput.PrintInvalidMoveMessage();

                Assert.AreEqual(message, consoleOutput.GetOuput());
            }

            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void PrintWelcomeMessage()
        {
            var currentConsoleOut = Console.Out;

            string message = "\nWelcome to “Labirinth” game. Please try to escape. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.\r\n";

            using (var consoleOutput = new ConsoleOutput())
            {
                LabyrinthInputOutput.PrintWelcomeMessage();

                Assert.AreEqual(message, consoleOutput.GetOuput());
            }

            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void PrintInputMessage()
        {
            var currentConsoleOut = Console.Out;

            string message = "Enter your move (L=left, R-right, U=up, D=down): \r\n";

            using (var consoleOutput = new ConsoleOutput())
            {
                LabyrinthInputOutput.PrintInputMessage();

                Assert.AreEqual(message, consoleOutput.GetOuput());
            }

            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void PrintInvalidCommandMessage()
        {
            var currentConsoleOut = Console.Out;

            string message = "You entered invalid command! Please, choose one of the below:\n" + 
            "R, L, U, D, Restart, Top, Exit\r\n";

            using (var consoleOutput = new ConsoleOutput())
            {
                LabyrinthInputOutput.PrintInvalidCommandMessage();

                Assert.AreEqual(message, consoleOutput.GetOuput());
            }

            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void PrintVictoryMessage_Six()
        {
            var currentConsoleOut = Console.Out;

            string message = "Congratulations! You escaped in " + "6" + " moves.\r\n";

            using (var consoleOutput = new ConsoleOutput())
            {
                LabyrinthInputOutput.PrintVictoryMessage("6");

                Assert.AreEqual(message, consoleOutput.GetOuput());
            }

            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PrintVictoryMessage_Zero()
        {
            var currentConsoleOut = Console.Out;

            string message = "Congratulations! You escaped in " + "0" + " moves.\r\n";

            using (var consoleOutput = new ConsoleOutput())
            {
                LabyrinthInputOutput.PrintVictoryMessage("0");

                Assert.AreEqual(message, consoleOutput.GetOuput());
            }

            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PrintVictoryMessage_NegativeNumber()
        {
            var currentConsoleOut = Console.Out;

            string message = "Congratulations! You escaped in " + "-6" + " moves.\r\n";

            using (var consoleOutput = new ConsoleOutput())
            {
                LabyrinthInputOutput.PrintVictoryMessage("-6");

                Assert.AreEqual(message, consoleOutput.GetOuput());
            }

            Assert.AreEqual(currentConsoleOut, Console.Out);
        }
    }
}
