using System;

namespace Waterskibaan
{
    public class Waterskibaan
    {
        public Kabel kabel { get; set; } = new Kabel();
        public LijnenVoorraad voorraad = new LijnenVoorraad();

        public Waterskibaan(Kabel kabel)
        {
            for (int i = 0; i < 15; i++)
            {
                voorraad.LijnToevoegenAanRij(new Lijn(i));

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
            if (kabel.IsStartPositieLeeg() && voorraad.GetAantalLijnen() != 0)
            {
                Lijn lijn1 = voorraad.VerwijderEersteLijn();
                lijn1.Sporter = sporter;
                kabel.NeemLijnInGebruik(lijn1);
                Random rnd = new Random();
                sporter.AantalRondenNogTeGaan = rnd.Next(1, 3);
            }
            if (sporter.Skies == null || sporter.Zwemvest == null)
            {
                throw new Exception("de Sporter heeft geen zwemvest of skie!");
            }
        }


    }
}
