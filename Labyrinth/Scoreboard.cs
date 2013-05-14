using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    public class Scoreboard
    {
        #region Fields

        private readonly List<Tuple<uint, string>> scoreboard;

        #endregion

        public Scoreboard()
        {
            this.scoreboard = new List<Tuple<uint, string>>();
        }

        public List<Tuple<uint, string>> ScoreboardList
        {
            get
            {
                return this.scoreboard;
            }
        }

        public void HandleScoreboard(uint moveCount)
        {
            if (this.scoreboard.Count() >= 5 && moveCount > this.scoreboard.Last().Item1)
            {
                Console.WriteLine("Your not good enough for the scoreboard :)");
                return;
            }

            if (this.scoreboard.Count == 0 ||
                (this.scoreboard.Count < 5 && this.scoreboard.Last().Item1 < moveCount))
            {
                Console.Write("Please enter your name for the top scoreboard: ");
                string nickname = Console.ReadLine();
                this.scoreboard.Add(new Tuple<uint, string>(moveCount, nickname));
                Console.WriteLine(this.ToString());
                return;
            }

            for (int i = 0; i < this.scoreboard.Count(); ++i)
            {
                if (moveCount <= this.scoreboard[i].Item1)
                {
                    Console.Write("Please enter your name for the top scoreboard: ");
                    string nickname = Console.ReadLine();
                    this.scoreboard.Insert(i, new Tuple<uint, string>(moveCount, nickname));
                    if (this.scoreboard.Count > 5)
                    {
                        this.scoreboard.Remove(this.scoreboard.Last());
                    }

                    Console.WriteLine(this.ToString());
                    break;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            if (this.scoreboard.Count == 0)
            {
                toString.AppendLine("The scoreboard is empty.");
            }
            
            for (int i = 0; i < this.scoreboard.Count; i++)
            {
                toString.AppendLine((i + 1).ToString() + ". " + this.scoreboard[i].Item2 + " --> " + 
                this.scoreboard[i].Item1.ToString() + " moves.");
            }

            return toString.ToString();
        }
    }
}
