using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib
{
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Wins { get; set; } = 0;
        public int Loses { get; set; } = 0;
        public int Draws { get; set; } = 0;

        public Player(int ID,string name,string surname,int wins,int loses,int draws) 
        {
            this.ID = ID;
            this.Name = name;
            this.Surname = surname;
            this.Wins = wins;
            this.Loses = loses;
            this.Draws = draws;
        }
        public Player() 
        {
            this.ID=0;
            this.Name = "John";
            this.Surname = "Doe";
        }
    }
}
