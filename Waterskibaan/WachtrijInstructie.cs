namespace Waterskibaan
{
    public class WachtrijInstructie : Wachtrij
    {
        public override int MAX_LENGTE_RIJ { get; } = 96;

        public void BijNieuweBezoeker(NieuweBezoekersArgs args)
        {
            SporterNeemPlaatsInRij(args.Sporter);
        }

    }
}
