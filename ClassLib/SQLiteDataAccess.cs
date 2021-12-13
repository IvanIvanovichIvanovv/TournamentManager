using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace ClassLib
{
    public class SQLiteDataAccess
    {
        #region Load Data
        public static List<Player> LoadPlayers()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Player>("select * from Players", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<Tournament> LoadTournaments()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Tournament>("select * from Tournaments", new DynamicParameters());
                return output.ToList();
            }
        }
        public static List<Match> LoadAllMatches()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Match>("select * from Matches", new DynamicParameters());
                return output.ToList();
            }
        }
        #endregion 
        #region Add Data
        public static void AddPlayer(Player player)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Players (Name, Surname, Wins, Loses, Draws) values (@Name, @Surname, @Wins, @Loses, @Draws)", player);
            }
        }
        public static void AddTournament(Tournament tournament)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Tournaments (Name) values (@Name)", tournament);
            }
        }
        public static void AddMatch(Match match)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Matches (Player1ID, Player2ID, WinnerID, TournamentID) values (@Player1ID, @Player2ID, @WinnerID, @TournamentID)", match);
            }
        }
        #endregion
        #region Update Data
        public static void UpdateMatch(Match match, int WinnerID)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"UPDATE Matches SET WinnerID={WinnerID} WHERE ID={match.ID}");
            }
        }
        public static void UpdatePlayer(Player player)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute($"UPDATE Players SET Name={player.Name}, Surname={player.Surname}, Wins={player.Wins}, Loses={player.Loses}, Draws={player.Draws} WHERE ID={player.ID}");
            }
        }
        //publis static void UpdatePlayerData(Player,)
        #endregion
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
