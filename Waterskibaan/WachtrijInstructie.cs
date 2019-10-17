using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class WachtrijInstructie : Wachtrij
    {
        public int MAX_LENGTE_RIJ = 100;
        
        public override bool Aantal(int aantal)
        {
            return aantal <= MAX_LENGTE_RIJ;
        }
        public void BijNieuweBezoeker(NieuweBezoekersArgs args)
        {
            SporterNeemPlaatsInRij(args.Sporter);
        }

        public override string ToString()
        {
            return $"Wachtrij instructie: {GetAlleSporters().Count} wachtenden";
        }
    }
}
