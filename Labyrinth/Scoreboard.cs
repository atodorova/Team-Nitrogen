using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labyrinth
{
    /// <summary>
    /// Keeps first five players with maximal score, checks if there is a better score and prints the result
    /// </summary>
    public class Scoreboard
    {
        public const int TopPlayersToShow = 5;
        private readonly List<Tuple<uint, string>> scoreboard;

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

        /// <summary>
        /// Adds final scores to the scoreboard after each successful game and prints the results to the console
        /// </summary>
        /// <param name="moveCount">total moves used to finish the game</param>
        public string HandleScoreboard(uint moveCount, string nickname)
        {
            StringBuilder sb = new StringBuilder();
            if (this.scoreboard.Count() >= TopPlayersToShow && moveCount > this.scoreboard.Last().Item1)
            {
                return "Your not good enough for the scoreboard :)\r\n";     
            }

            if (this.scoreboard.Count == 0 ||
                (this.scoreboard.Count < TopPlayersToShow && this.scoreboard.Last().Item1 < moveCount))
            {
                this.scoreboard.Add(new Tuple<uint, string>(moveCount, nickname));
                return this.ToString();
            }

            for (int i = 0; i < this.scoreboard.Count(); ++i)
            {
                if (moveCount <= this.scoreboard[i].Item1)
                {
                    this.scoreboard.Insert(i, new Tuple<uint, string>(moveCount, nickname));
                    if (this.scoreboard.Count > TopPlayersToShow)
                    {
                        this.scoreboard.Remove(this.scoreboard.Last());
                    }

                    return this.ToString();
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Common ToString method
        /// </summary>
        /// <returns>Players with maximal score(minimal moves count)</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this.scoreboard.Count == 0)
            {
                sb.AppendLine("The scoreboard is empty.");
            }
            
            for (int i = 0; i < this.scoreboard.Count; i++)
            {
                sb.AppendFormat("{0}. {1} --> {2} moves.", i + 1, this.scoreboard[i].Item2, this.scoreboard[i].Item1);
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
