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
    }
}
