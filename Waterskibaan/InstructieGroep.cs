using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class InstructieGroep : Wachtrij
    {

        public int MAX_LENGTE_RIJ = 5;

        public override bool Aantal(int aantal)
        {
            return aantal <= MAX_LENGTE_RIJ;
        }

        public void InstructieIsAfgelopen(InstructieAfgelopenArgs args)
        {
            foreach (Sporter sporter in args.NieuweSporters)
            {
                SporterNeemPlaatsInRij(sporter);
            }
        }

        public override string ToString()
        {
            return $"Instructie groep: {GetAlleSporters().Count} wachtenden";
        }
    }
}
