using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class Match
    {
        int ID { get; set; }    
        int Player1ID { get; set; } 
        int Player2ID { get; set; }
        int WinnerID { get; set; }
        int TournamentID { get; set; }

        public Match(int Player1ID, int Player2ID, int TournamentID) 
        {
            this.Player1ID = Player1ID;
            this.Player2ID = Player2ID;
            this.TournamentID = TournamentID;
        }
    }
}
