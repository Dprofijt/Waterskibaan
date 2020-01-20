using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using Waterskibaan;

namespace WaterskibaanWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game game;
        private WachtrijInstructie wachtrijInstructie;
        private InstructieGroep instructieGroep;
        private WachtrijStarten wachtrijStarten;
        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            game = new Game();

            game.Initialize(timer);
            timer.Tick += RunGame;
        }

        public void RunGame(object source, EventArgs args)
        {
            updatelabels();
            InstructieGroepWachtrijTekenen();
            InstructieGroepTekenen();
            WachtrijStartTekenen();
            SkibaanTekenen();
        }

        public void InstructieGroepWachtrijTekenen()
        {
            wachtrijInstructie = game.wachtrijInstructie;
            int x = 0;
            int y = 0;
            canvas_wachtrij_instructiegroep.Children.Clear();
            Rectangle rect;
            foreach (Sporter sporter in wachtrijInstructie.GetAlleSporters())
            {
                rect = GetSporter(sporter);
                Canvas.SetLeft(rect, x);
                Canvas.SetTop(rect, y);
                canvas_wachtrij_instructiegroep.Children.Add(rect);

                if (x >= 345)
                {
                    y += 20;
                    x = 0;
                }
                else
                {
                    x += 15;
                }
            }
        }
        public void InstructieGroepTekenen()
        {
            instructieGroep = game.instructieGroep;
            Sporter sporter;
            Rectangle rect;
            int x = 0;
            int y = 0;


            for (int i = 0; i < instructieGroep.GetAlleSporters().Count; i++)
            {
                sporter = instructieGroep.GetAlleSporters()[i];
                rect = GetSporter(sporter);
                Canvas.SetTop(rect, y);
                Canvas.SetLeft(rect, x);
                canvas_instructiegroep.Children.Add(rect);
                x += 15;
            }
        }

        public void WachtrijStartTekenen()
        {
            wachtrijStarten = game.wachtrijStarten;
            Rectangle rect;
            int x = 0;
            int y = 0;
            canvas_wachtrijStart.Children.Clear();
            foreach (Sporter sporter in wachtrijStarten.GetAlleSporters())
            {
                rect = GetSporter(sporter);
                Canvas.SetLeft(rect, x);
                Canvas.SetTop(rect, y);
                canvas_wachtrijStart.Children.Add(rect);

                if (x >= 345)
                {
                    y += 20;
                    x = 0;
                }
                else
                {
                    x += 15;
                }
            }
        }
        public void SkibaanTekenen()
        {
            int x;
            int y = 0;
            canvas_waterskibaan.Children.Clear();
            LinkedList<Waterskibaan.Lijn> lijnen = game.waterskibaan.kabel._lijnen;
            for (int i = 0; i < lijnen.Count; i++)
            {
                x = lijnen.ElementAt(i).PositieOpDeKabel * 60;
                Lijn lijn = lijnen.ElementAt(i);
                Rectangle rect = GetSportervanLijn(lijn);
                Canvas.SetLeft(rect, x);
                Canvas.SetTop(rect, y);
                canvas_waterskibaan.Children.Add(rect);


                Label plek = new Label();
                Label move = new Label();

                plek.Content = $" lijn : {lijn.ID}";
                Canvas.SetLeft(plek, x);
                Canvas.SetTop(plek, y + 30);
                canvas_waterskibaan.Children.Add(plek);
                if (lijn.Sporter.move != null)
                {
                    move.Content = lijn.Sporter.move.naam;
                    Canvas.SetLeft(move, x);
                    Canvas.SetTop(move, y + 60);

                    canvas_waterskibaan.Children.Add(move);

                }
            }

        }
        public Rectangle GetSportervanLijn(Lijn lijn)
        {
            SolidColorBrush fillBrush = new SolidColorBrush(Color.FromRgb(lijn.Sporter.KledingKleur.R, lijn.Sporter.KledingKleur.G, lijn.Sporter.KledingKleur.B));
            SolidColorBrush strokeBrush = new SolidColorBrush(Colors.Black);
            Rectangle rect = new Rectangle
            {
                Stroke = strokeBrush,
                Fill = fillBrush,
                Height = 20,
                Width = 20,
            };

            return rect;
        }


        public Rectangle GetSporter(Sporter sporter)
        {
            SolidColorBrush fillBrush = new SolidColorBrush(Color.FromRgb(sporter.KledingKleur.R, sporter.KledingKleur.G, sporter.KledingKleur.B));
            SolidColorBrush strokeBrush = new SolidColorBrush(Colors.Black);
            Rectangle rect = new Rectangle
            {
                Stroke = strokeBrush,
                Fill = fillBrush,
                Height = 10,
                Width = 10,
            };

            return rect;
        }

        public void updatelabels()
        {
            label_sportersCount.Content = $"Er zijn in totaal {game.logger.GetAantalSporters()} sporters geweest";
            label_lijnenvooraad.Content = $"Er zijn {game.waterskibaan.voorraad.GetAantalLijnen()} lijnen op voorraad";
            label_hoeveelheidRodeShirts.Content = $"Er waren {game.logger.GetAantalRodeShirts()} sporters met rode kleding";
            label_topScore.Content = $"De hoogste score is { game.logger.GetHoogsteScore()}";
            label_totalerondes.Content = $"er zijn {game.logger.GetAantalRonden()} aantal rondes gedaan";
            Label_uniekemoves.Content = $"De unieke moves waren: \n {game.logger.GetUniekemoves() }";
            LichtsteKleur();
        }
        public void LichtsteKleur()
        {
            List<Sporter> lichtsteSporters = game.logger.GetTienLichtsteSporters();
            canvas_lichtsteSporters.Children.Clear();
            int x = 0;
            int y = 0;
            foreach (Sporter sporter in lichtsteSporters)
            {
                Rectangle rect = GetSporter(sporter);
                Canvas.SetLeft(rect, x);
                Canvas.SetTop(rect, y);
                canvas_lichtsteSporters.Children.Add(rect);

                if (x >= 48)
                {
                    y = y + 12;
                    x = 0;
                }
                else
                {
                    x = x + 12;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }
    }
}
