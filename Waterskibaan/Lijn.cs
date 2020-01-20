namespace Waterskibaan
{
    public class Lijn
    {
        public int PositieOpDeKabel { get; set; }
        public Sporter Sporter { get; set; }

        public int ID { get; set; }
        public Lijn(int ID)
        {
            this.ID = ID;
        }
    }
}
