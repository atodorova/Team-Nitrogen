using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    public class Top5Scoreboard
    {
        #region Fields

        List<Tuple<uint, string>> scoreboard;

        #endregion

        public Top5Scoreboard()
        {
            this.scoreboard = new List<Tuple<uint, string>>();
        }

        public void HandleScoreboard(uint moveCount)
        {
            if (this.scoreboard.Count() >= 5 && moveCount > this.scoreboard.Last().Item1)
            {
                Console.WriteLine("Your not good enough for the scoreboard :)");
                return;
            }

            if (this.scoreboard.Count == 0 ||
                (this.scoreboard.Count < 5) && this.scoreboard.Last().Item1 < moveCount)
            {
                string nickname = this.ShowScoreboardInMessage();
                this.scoreboard.Add(new Tuple<uint, string>(moveCount, nickname));
                this.ShowScoreboard();
                return;
            }

            for (int i = 0; i < this.scoreboard.Count(); ++i)
            {
                if (moveCount <= this.scoreboard[i].Item1)
                {
                    string nickname = this.ShowScoreboardInMessage();
                    this.scoreboard.Insert(i, new Tuple<uint, string>(moveCount, nickname));
                    if (this.scoreboard.Count > 5)
                    {
                        this.scoreboard.Remove(this.scoreboard.Last());
                    }

                    this.ShowScoreboard();
                    break;
                }
            }
        }

        public void ShowScoreboard()
        {
            if (this.scoreboard.Count == 0)
            {
                Console.WriteLine("The scoreboard is empty.");
                return;
            }

            for (int i = 0; i < this.scoreboard.Count; ++i)
            {
                Console.Write((i + 1).ToString() + ". " + this.scoreboard[i].Item2 + " --> ");
                Console.WriteLine(this.scoreboard[i].Item1.ToString() + " moves.");
            }
        }

        private string ShowScoreboardInMessage()
        {
            Console.Write("Please enter your name for the top scoreboard: ");
            string nickname = Console.ReadLine();
            return nickname;
        }
    }
}
