using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class SQLiteDataAccess
    {
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
        public static List<Match> LoadMatches()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<Match>("select * from Matches", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void AddPlayer(Player player) 
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Players (Name, Surname, Wins, Loses, Draws) values (@Name, @Surname, @Wins, @Loses, @Draws)", player);
            }
        }

        private static string LoadConnectionString(string id = "Default") 
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
