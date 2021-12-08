using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentManager.Classes
{
    internal class Player
    {
        int id { get; set; }
        string name { get; set; }
        string surname { get; set; }
        int wins { get; set; } = 0;
        int loses { get; set; } = 0;
        int draws { get; set; } = 0;
    }
}
