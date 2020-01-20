using System.Collections.Generic;

namespace Waterskibaan
{
    public class LijnenVoorraad
    {
        private Queue<Lijn> _lijnen = new Queue<Lijn>();

        public void LijnToevoegenAanRij(Lijn lijn)
        {
            _lijnen.Enqueue(lijn);
        }


        public Lijn VerwijderEersteLijn()
        {


            if (_lijnen.Count > 0)
            {
                Lijn lijn = _lijnen.Dequeue();
                return lijn;
            }
            else
            {
                return null;
            }

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
