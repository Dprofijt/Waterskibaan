using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class LijnenVoorraad
    {
        private Queue<Lijn> _lijnen { get; set; }

        public void LijnToevoegenAanRij(Lijn lijn)
        {
            _lijnen.Enqueue(lijn);
        }
        

        public Lijn VerwijderEersteLijn()
        {
            Lijn lijn = null;

            if (_lijnen.Count > 0)
                lijn = _lijnen.Dequeue();

            return lijn;


        }

        public int GetAantalLijnen()
        {
            int aantal = _lijnen.Count;
            return aantal;
        }

        public override string ToString()
        {
            return $"{this.GetAantalLijnen()} lijnen op voorraad";
        }

    }
}
