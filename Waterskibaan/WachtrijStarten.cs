using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class WachtrijStarten : Wachtrij
    {
        public int MAX_LENGTE_RIJ = 20;

        public override bool Aantal(int aantal)
        {
            return aantal <= MAX_LENGTE_RIJ;
        }

        public void InstructieIsAfgelopen(InstructieAfgelopenArgs args)
        {
            foreach (Sporter sporter in args.SportersKlaar)
            {
                SporterNeemPlaatsInRij(sporter);
            }
        }

        public override string ToString()
        {
            return $"Wachtrij starten: {GetAlleSporters().Count} sporters zijn aan het wachten";
        }
    }
}
