using System;
using System.Windows.Threading;

namespace Waterskibaan
{
    public class Game
    {
        public Waterskibaan waterskibaan;
        private Random random = new Random();
        public WachtrijInstructie wachtrijInstructie;
        public InstructieGroep instructieGroep;
        public WachtrijStarten wachtrijStarten;
        private DispatcherTimer tijd;
        public int tickCount = 0;
        public Logger logger;

        public delegate void NieuweBezoekerHandler(NieuweBezoekersArgs args);
        public event NieuweBezoekerHandler NieuweBezoeker;

        public delegate void InstrutieAfgelopenHandler(InstructieAfgelopenArgs args);
        public event InstrutieAfgelopenHandler InstructieAfgelopen;



        public void Initialize(DispatcherTimer tijd)
        {
            wachtrijInstructie = new WachtrijInstructie();
            instructieGroep = new InstructieGroep();
            wachtrijStarten = new WachtrijStarten();
            Kabel kabel = new Kabel();

            NieuweBezoeker += wachtrijInstructie.BijNieuweBezoeker;
            InstructieAfgelopen += wachtrijStarten.InstructieIsAfgelopen;
            InstructieAfgelopen += instructieGroep.InstructieIsAfgelopen;

            waterskibaan = new Waterskibaan(kabel);
            logger = new Logger(waterskibaan.kabel);

            this.tijd = tijd;
            tijd.Interval = TimeSpan.FromMilliseconds(100);
            tijd.Tick += OnInstructieIsAfgelopen;
            tijd.Tick += BijNieuweBezoeker;
            tijd.Tick += VerplaatsLijnen;
            tijd.Tick += VerhoogTijd;

            tijd.Start();
        }

        private void VerhoogTijd(object source, EventArgs e)
        {
            tickCount++;
        }
        private void BijNieuweBezoeker(object source, EventArgs e)
        {
            if (tickCount % 3 == 0)
            {
                Sporter sporternu = new Sporter();
                logger.sporters.Add(sporternu);
                NieuweBezoeker?.Invoke(new NieuweBezoekersArgs { Sporter = sporternu });
            }
        }

        private void OnInstructieIsAfgelopen(object source, EventArgs e)
        {
            if (tickCount % 20 == 0)
            {
                InstructieAfgelopenArgs afgelopenArgs = new InstructieAfgelopenArgs()
                {
                    SportersKlaar = instructieGroep.SportersVerlatenRij(5),
                    NieuweSporters = wachtrijInstructie.SportersVerlatenRij(5)
                };
                InstructieAfgelopen?.Invoke(afgelopenArgs);
            }
        }
        private void VerplaatsLijnen(object source, EventArgs e)
        {
            Sporter sporterStart = null;

            if (tickCount % 4 == 0)
            {
                waterskibaan.VerplaatsKabel();
                if (waterskibaan.kabel.IsStartPositieLeeg() && wachtrijStarten.GetAlleSporters().Count != 0 && waterskibaan.voorraad.GetAantalLijnen() != 0)
                {
                    sporterStart = wachtrijStarten.SportersVerlatenRij(1)[0];
                    sporterStart.Skies = new Skies();
                    sporterStart.Zwemvest = new Zwemvest();
                    waterskibaan.SporterStart(sporterStart);
                }
                foreach (Lijn lijn in waterskibaan.kabel._lijnen)
                {
                    lijn.Sporter.move = null;
                    int r = random.Next(100);
                    if (r >= 70)
                    {
                        lijn.Sporter.DoeMove();
                    }
                }
            }
        }
    }
}
