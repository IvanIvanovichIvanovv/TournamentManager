using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class Player
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public int wins { get; set; } = 0;
        public int loses { get; set; } = 0;
        public int draws { get; set; } = 0;

        public Player(int ID,string name,string surname,int wins,int loses,int draws) 
        {
            this.id = ID;
            this.name = name;
            this.surname = surname;
            this.wins = wins;
            this.loses = loses;
            this.draws = draws;
        }
        public Player() 
        {
            this.id=0;
            this.name = "John";
            this.surname = "Doe";
        }
    }
}
