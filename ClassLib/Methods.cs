using System.Collections.Generic;
using System.Linq;

namespace ClassLib
{
    public static class Methods
    {
        public static List<Player> AllPlayers = new List<Player>();
        public static List<Player> ChosenPlayers = new List<Player>();
        public static List<Match> CurrentMatches = new List<Match>();
        public static List<Match> Matches = new List<Match>();
        public static List<Tournament> Tournaments = new List<Tournament>();
        public static Tournament CurrentTournament;
        public static void LoadPlayers()
        {
            AllPlayers = SQLiteDataAccess.LoadPlayers();
        }
        public static void LoadTournaments()
        {
            Tournaments = SQLiteDataAccess.LoadTournaments();
        }
        public static void LoadMatches()
        {
            Matches = SQLiteDataAccess.LoadAllMatches();
        }
        public static void AddPlayerToListWoDuplicates(List<Player> players, Player player)
        {
            int check = 0;
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].ID == player.ID)
                {
                    check = 1;
                    break;
                }
            }
            if (check == 0)
            {
                players.Add(player);
            }
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
                match.WinnerID = 1;
                SQLiteDataAccess.UpdatePlayer(player1);
                SQLiteDataAccess.UpdatePlayer(player2);
                SQLiteDataAccess.UpdateMatch(match, 1);
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
            CurrentMatches.Clear();

            Tournament tournament = new Tournament(Name);
            SQLiteDataAccess.AddTournament(tournament);

            LoadTournaments();
            RoundRobin(players, CurrentMatches, Tournaments[Tournaments.Count - 1]);
            for (int i = 0; i < CurrentMatches.Count; i++)
            {
                SQLiteDataAccess.AddMatch(CurrentMatches[i]);
            }
        }
        public static void EditPlayerData(Player player, string Name, string Surname, int Wins, int Loses, int Draws)
        {
            player.Name = Name;
            player.Surname = Surname;
            player.Wins = Wins;
            player.Draws = Draws;
            player.Loses = Loses;
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
