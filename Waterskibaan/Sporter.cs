using System;
using System.Collections.Generic;
using System.Drawing;

namespace Waterskibaan
{
    public class Sporter
    {
        public int AantalRondenNogTeGaan { get; set; }
        public Zwemvest Zwemvest { get; set; }
        public Skies Skies { get; set; }
        public Color KledingKleur { get; set; }
        public List<IMoves> Moves { get; set; }
        public int aantalPunten { get; set; }
        public IMoves move { get; set; }

        public Sporter()
        {
            Random rnd = new Random();
            int rnd1 = rnd.Next(255);
            int rnd2 = rnd.Next(255);
            int rnd3 = rnd.Next(255);
            int rnd4 = rnd.Next(255);
            aantalPunten = 0;
            Moves = MoveCollection.GetWillekeurigeMoves();
            KledingKleur = Color.FromArgb(rnd1, rnd2, rnd3, rnd4);
        }

        public bool DoeMove()
        {
            if (Moves.Count != 0)
            {
                Random rnd = new Random();
                move = Moves[rnd.Next(Moves.Count)];
                aantalPunten += move.Move();
                return true;
            }
            return false;
        }

    }
}
