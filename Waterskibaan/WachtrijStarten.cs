namespace Waterskibaan
{
    public class WachtrijStarten : Wachtrij
    {
        public override int MAX_LENGTE_RIJ { get; } = 20;
        public void InstructieIsAfgelopen(InstructieAfgelopenArgs args)
        {
            foreach (Sporter sporter in args.SportersKlaar)
            {
                SporterNeemPlaatsInRij(sporter);
            }
        }
    }
}
