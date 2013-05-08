using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
	// Nothing is more admirable than the fortitude with which millionaires tolerate the disadvantages of their wealth.

    class KPK_PROEKT
    {

        static void Main(string[] args)
        {
            LabyrinthProcesor processor = new LabyrinthProcesor();

            while (true)
            {
                processor.ShowLabyrinth();
                processor.ShowInputMessage();
                string input;
                input = Console.ReadLine();
                processor.HandleInput(input);
            }
        }
    }
}
