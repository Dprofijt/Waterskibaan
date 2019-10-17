using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Kabel
    {
        public LinkedList<Lijn> _lijnen = new LinkedList<Lijn>();


        public Boolean IsStartPositieLeeg()
        {
            if (_lijnen.First.Value == null)
            {
                return true;
            }
            return false;
        }

        public void NeemLijnInGebruik(Lijn lijn)
        {
            if(_lijnen.First.Value == null)
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
                    lijn.PositieOpDeKabel = 0;
                }
                else
                {
                    lijn.PositieOpDeKabel = lijn.PositieOpDeKabel + 1;
                }
            }
            if (moveLijn != null)
            {
                moveLijn.PositieOpDeKabel = 0;

                if( moveLijn.Sporter.AantalRondenNogTeGaan != 1)
                {
                    moveLijn.Sporter.AantalRondenNogTeGaan= moveLijn.Sporter.AantalRondenNogTeGaan - 1;
                }

                _lijnen.Remove(moveLijn);
                _lijnen.AddFirst(moveLijn);
            }

        }

        public Lijn VerwijderLijnVanKabel()
        {
            if (_lijnen.Count == 0 || _lijnen.Last.Value.PositieOpDeKabel != 9 || _lijnen.Last.Value.Sporter.AantalRondenNogTeGaan != 1)
            {
                return null;
            }

            Lijn lijn = _lijnen.Last.Value;

            _lijnen.RemoveLast();

            return lijn;
        }

        public override string ToString()
        {
            if (_lijnen.Count == 0)
            {
                return "";
            }

            string resultaat = "";

            foreach(Lijn lijn in _lijnen)
            {
                resultaat += $"{lijn.PositieOpDeKabel}|";
            }
            return resultaat.Substring(0, resultaat.Length - 1);

        }

    }
}
