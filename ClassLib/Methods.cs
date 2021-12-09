using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    internal static class Methods
    {
        public static void roundRobin(List<Player> players, List<Match> matches,Tournament tournament)
        {
            for (int j = 0; j < players.Count() - 1; j++)
            {
                for (int l = 1; l <= players.Count() - 1; l++)
                {
                    if (j + l < players.Count())
                    {
                        if ((l + 1) % 2 == 0)
                        {
                            matches.Add(new Match(players[j].ID, players[j + l].ID, tournament.ID)); //($"{players[j]} vs {players[j + l]}")
                        }
                        else
                        {
                            matches.Add(new Match(players[j + l].ID, players[j].ID, tournament.ID));
                        }

                    }
                }
            }
        }
    }
}
