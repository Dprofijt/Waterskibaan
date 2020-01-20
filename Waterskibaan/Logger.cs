using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Waterskibaan
{
    public class Logger
    {
        public Kabel kabel;
        public List<Sporter> sporters = new List<Sporter>();

        public Logger(Kabel kabel)
        {
            this.kabel = kabel;
        }

        public bool ColorsAreClose(Color a, Color z, int threshold)
        {
            int r = a.R - z.R;
            int g = a.G - z.G;
            int b = a.B - z.B;

            return (r * r + g * g + b * b) <= threshold * threshold;
        }
        public int GetAantalRonden()
        {
            return kabel.TotaleRonden;
        }
        public int GetAantalSporters()
        {
            return sporters.Count;
        }
        public int GetHoogsteScore()
        {
            return sporters.Max(sporter => sporter.aantalPunten);
        }
        public int GetAantalRodeShirts()
        {
            return (
                from item in sporters
                where ColorsAreClose(item.KledingKleur, Color.Red, 150)
                select item
                ).ToList().Count();
        }
        public string GetUniekemoves()
        {
            List<IMoves> moves = new List<IMoves>();

            foreach (Lijn lijn in kabel._lijnen)
            {
                lijn.Sporter.Moves.ForEach(move => moves.Add(move));
            }
            List<string> uniekeMoves = (from item in moves orderby item.naam select item.naam).Distinct().ToList();

            string movesString = "";
            foreach (string move in uniekeMoves)
            {
                movesString += $"{move}, ";
            }
            if (movesString.Length != 0)
            {
                movesString = movesString.Substring(0, movesString.Length - 2);
            }
            return movesString;
        }
        private int GetLichtheid(Color kleur)
        {
            return kleur.R * kleur.R + kleur.G * kleur.G + kleur.B * kleur.B;
        }
        public List<Sporter> GetTienLichtsteSporters()
        {
            return (
                from item in sporters
                orderby GetLichtheid(item.KledingKleur) descending
                select item).Take(10).ToList();
        }

    }
}
