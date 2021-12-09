using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    internal static class Methods
    {
        public static bool CheckIfPlayerBelongsToMatch(Match match,int playerID) 
        {
            if (match.Player2ID == playerID || match.Player1ID == playerID)
            {
                return true;
            }
            else return false;
        }
        public static void SetMatchWinner(Match match,Player Winner, Player Loser) 
        {
            if (CheckIfPlayerBelongsToMatch(match, Winner.ID) && CheckIfPlayerBelongsToMatch(match, Loser.ID)) 
            {
                Winner.Wins += 1;
                Loser.Loses += 1;
                match.WinnerID= Winner.ID;
                SQLiteDataAccess.UpdatePlayerResults(Loser);
                SQLiteDataAccess.UpdatePlayerResults(Winner);
                SQLiteDataAccess.UpdateMatch(match,Winner.ID);
            }
        }
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
