namespace ClassLib
{
    public class Match
    {
        public int ID { get; set; }
        public int Player1ID { get; set; }
        public int Player2ID { get; set; }
        public int WinnerID { get; set; }
        public int TournamentID { get; set; }

        public Match(int Player1ID, int Player2ID, int TournamentID)
        {
            this.Player1ID = Player1ID;
            this.Player2ID = Player2ID;
            this.TournamentID = TournamentID;
        }
    }
}
