namespace ClassLib
{
    public class Tournament
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Tournament(string Name) 
        {
            this.Name = Name; 
        }
        public Tournament(int ID, string Name) 
        {
            this.ID = ID;    
            this.Name = Name;
        }
        public Tournament() { }
    }
}
