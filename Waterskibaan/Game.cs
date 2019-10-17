using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Threading;

namespace Waterskibaan
{
    public class Game
    {
        private Waterskibaan waterskibaan = new Waterskibaan();
        private WachtrijInstructie wachtrijInstrucie = new WachtrijInstructie();
        private InstructieGroep instructieGroep = new InstructieGroep();
        private WachtrijStarten wachtrijStarten = new WachtrijStarten();
        private static DispatcherTimer tijd;

        public delegate void NieuweBezoekerHandler(NieuweBezoekersArgs args);
        public event NieuweBezoekerHandler NieuweBezoeker;

        public delegate void InstrutieAfgelopenHandler(InstructieAfgelopenArgs args);
        public event InstrutieAfgelopenHandler InstructieAfgelopen;

        public delegate void VerplaatsLijnenHandler();
        public event VerplaatsLijnenHandler verplaatsLijnen;
        public int seconden;

        public void Initialize(DispatcherTimer timer)
        {
            tijd = timer;
            NieuweBezoeker += wachtrijInstrucie.BijNieuweBezoeker;
            InstructieAfgelopen += instructieGroep.InstructieIsAfgelopen;
            InstructieAfgelopen += wachtrijStarten.InstructieIsAfgelopen;
            SetTimer();

            NieuweBezoeker += BijNieuweBezoeker;
            InstructieAfgelopen += InstructieIsAfgelopen;
            verplaatsLijnen += VerplaatsLijnen;

        }
        private void SetTimer()
        {

            tijd.Interval = TimeSpan.FromSeconds(1);
            tijd.Tick += OnTimer;
            tijd.IsEnabled = true;
            tijd.Start();
        }

        private void OnTimer(object source, EventArgs e)
        {
            seconden++;

            Console.WriteLine(waterskibaan);
            Console.WriteLine(wachtrijInstrucie);
            Console.WriteLine(instructieGroep);
            Console.WriteLine(wachtrijStarten);
        }
        private void BijNieuweBezoeker(EventArgs e)
        {
            if (seconden % 3 != 0) return;

            Sporter sporter = new Sporter(MoveCollection.GetWillekeurigeMoves());


            NieuweBezoeker?.Invoke(new NieuweBezoekersArgs { Sporter = sporter });
        }

        private void InstructieIsAfgelopen(EventArgs e)
        {
            if (seconden % 2 != 0)
            {
                return;
            }
            InstructieAfgelopen?.Invoke(new InstructieAfgelopenArgs
            {
                SportersKlaar = instructieGroep.SportersVerlatenRij(5),
                NieuweSporters = wachtrijInstrucie.SportersVerlatenRij(5)
            });


        }
        private void VerplaatsLijnen()
        {
            if (seconden % 4 != 0) return;
            waterskibaan.VerplaatsKabel();
            if (waterskibaan.kabel.IsStartPositieLeeg())
            {
                var sporter = wachtrijStarten.SportersVerlatenRij(1)[0];
                sporter.Skies = new Skies();
                sporter.Zwemvest = new Zwemvest();

                waterskibaan.SporterStart(sporter);



            }



        }
    }
}

