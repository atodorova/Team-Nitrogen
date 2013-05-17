using System;
using System.Linq;
using System.IO;

namespace LabyrinthTests
{
    public class ConsoleOutputTestHelper : IDisposable
    {
        private readonly StringWriter stringWriter;
        private readonly TextWriter originalOutput;
 
        public ConsoleOutputTestHelper()
        {
            stringWriter = new StringWriter();
            originalOutput = Console.Out;
            Console.SetOut(stringWriter);
        }
 
        public string GetOuput()
        {
            return stringWriter.ToString();
        }
 
        public void Dispose()
        {
            Console.SetOut(originalOutput);
            stringWriter.Dispose();
        }
    }
}
