using System.Collections.Generic;

namespace Waterskibaan
{
    public class Kabel
    {
        public LinkedList<Lijn> _lijnen = new LinkedList<Lijn>();
        public int TotaleRonden = 0;


        public bool IsStartPositieLeeg()
        {
            if (_lijnen.First == null || _lijnen.First.Value.PositieOpDeKabel != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void NeemLijnInGebruik(Lijn lijn)
        {
            if (IsStartPositieLeeg())
            {
                lijn.PositieOpDeKabel = 0;
                _lijnen.AddFirst(lijn);

            }
        }

        public void VerschuifLijnen()
        {
            Lijn moveLijn = null;
            foreach (Lijn lijn in _lijnen)
            {
                if (lijn.PositieOpDeKabel == 9)
                {
                    moveLijn = lijn;
                }
                else
                {
                    lijn.PositieOpDeKabel = lijn.PositieOpDeKabel + 1;
                }
            }
            if (moveLijn != null)
            {
                moveLijn.PositieOpDeKabel = 0;


                moveLijn.Sporter.AantalRondenNogTeGaan = moveLijn.Sporter.AantalRondenNogTeGaan - 1;


                _lijnen.Remove(moveLijn);
                _lijnen.AddFirst(moveLijn);
                TotaleRonden++;
            }

        }

        public Lijn VerwijderLijnVanKabel()
        {
            if (_lijnen.First != null)
            {
                Lijn lijn = _lijnen.First.Value;
                if (lijn.PositieOpDeKabel == 0 && lijn.Sporter.AantalRondenNogTeGaan == 0)
                {
                    _lijnen.RemoveFirst();

                    return lijn;
                }
            }
            return null;

        }

        public override string ToString()
        {
            if (_lijnen.Count == 0)
            {
                return "de kabel is leeg";
            }

            string resultaat = "";

            foreach (Lijn lijn in _lijnen)
            {
                resultaat += $"{lijn.PositieOpDeKabel} |";
            }
            return resultaat.Substring(0, resultaat.Length - 2);

        }

    }
}
