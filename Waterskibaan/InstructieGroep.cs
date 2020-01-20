namespace Waterskibaan
{
    public class InstructieGroep : Wachtrij
    {

        public override int MAX_LENGTE_RIJ { get; } = 5;

        public void InstructieIsAfgelopen(InstructieAfgelopenArgs args)
        {
            foreach (Sporter sporter in args.NieuweSporters)
            {
                SporterNeemPlaatsInRij(sporter);
            }
        }
    }
}
