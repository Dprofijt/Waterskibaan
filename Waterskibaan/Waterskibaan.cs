using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Waterskibaan
    {
        public Kabel kabel { get; set; } = new Kabel();
        private LijnenVoorraad voorraad { get; set; } = new LijnenVoorraad();

        public Waterskibaan()
        {
            for (int i = 0; i < 15; i++)
            {
                voorraad.LijnToevoegenAanRij(new Lijn());

            }
        }

        public void VerplaatsKabel()
        {
            kabel.VerschuifLijnen();
            Lijn lijn = kabel.VerwijderLijnVanKabel();

            if (lijn != null)
            {
                voorraad.LijnToevoegenAanRij(lijn);
            }
        }

        public override string ToString()
        {
            return $"aantal lijnen in voorraad {voorraad} en de {kabel}";
        }

        public void SporterStart(Sporter sporter)
        {
            if (!kabel.IsStartPositieLeeg())
            {
                return;
            }
            if( sporter.Skies == null || sporter.Zwemvest == null)
            {
                throw new Exception("de Sporter heeft geen zwemvest of skie!");
            }

            Lijn lijn = voorraad.VerwijderEersteLijn();
            lijn.Sporter = sporter;
            sporter.AantalRondenNogTeGaan = new Random().Next(1, 3);
            kabel.NeemLijnInGebruik(lijn);

        }


    }
}
