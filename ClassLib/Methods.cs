using System.Collections.Generic;
using System.Linq;

namespace ClassLib
{
    internal static class Methods
    {
        public static List<Player> AllPlayers;
        public static List<Player> ChosenPlayers;
        public static List<Match> Matches;
        public static List<Tournament> Tournaments;
        public static Tournament CurrentTournament;
        public static void LoadPlayers() 
        {
            AllPlayers = SQLiteDataAccess.LoadPlayers();
        }
        public static void LoadTournaments() 
        {
            Tournaments=SQLiteDataAccess.LoadTournaments();
        }
        public static bool CheckIfPlayerBelongsToMatch(Match match, int playerID)
        {
            if (match.Player2ID == playerID || match.Player1ID == playerID)
            {
                return true;
            }
            else return false;
        }
        public static void SetMatchWinner(Match match, Player Winner, Player Loser)
        {
            if (CheckIfPlayerBelongsToMatch(match, Winner.ID) && CheckIfPlayerBelongsToMatch(match, Loser.ID))
            {
                Winner.Wins += 1;
                Loser.Loses += 1;
                match.WinnerID = Winner.ID;
                SQLiteDataAccess.UpdatePlayer(Loser);
                SQLiteDataAccess.UpdatePlayer(Winner);
                SQLiteDataAccess.UpdateMatch(match, Winner.ID);
            }
        }
        public static void SetMatchDraw(Match match, Player player1, Player player2)
        {
            if (CheckIfPlayerBelongsToMatch(match, player1.ID) && CheckIfPlayerBelongsToMatch(match, player2.ID))
            {
                player1.Draws += 1;
                player2.Draws += 1;
                match.WinnerID = 0;
                SQLiteDataAccess.UpdatePlayer(player1);
                SQLiteDataAccess.UpdatePlayer(player2);
                SQLiteDataAccess.UpdateMatch(match, 0);
            }
        }
        public static Player CreatePlayer(string Name, string Surname)
        {
            Player player = new Player(Name, Surname);
            SQLiteDataAccess.AddPlayer(player);
            return player;
        }
        public static void CreateTournament(string Name, List<Player> players)
        {
            Tournaments.Clear();
            Matches.Clear();

            Tournament tournament = new Tournament(Name);
            SQLiteDataAccess.AddTournament(tournament);

            Tournaments = SQLiteDataAccess.LoadTournaments();
            RoundRobin(players, Matches, tournament);
            for (int i = 0; i < Matches.Count; i++) 
            {
                SQLiteDataAccess.AddMatch(Matches[i]);
            }
        }
        public static void EditPlayerData(Player player, string Name, string Surname, int Wins, int Loses, int Draws) 
        {
            player.Name= Name;
            player.Surname= Surname;    
            player.Wins= Wins;  
            player.Draws= Draws;
            player.Loses= Loses;
            SQLiteDataAccess.UpdatePlayer(player);
        }
        public static void RoundRobin(List<Player> players, List<Match> matches, Tournament tournament)
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
