using System;
using System.Collections.Generic;

namespace Waterskibaan
{
    public interface IMoves
    {
        string naam { get; }
        int Move();

    }


    class Jump : IMoves
    {
        public string naam { get => "jump"; }
        private int punten = 12;
        public int Move()
        {
            Random random = new Random();
            if (random.Next(100) > 70)
            {
                return 0;
            }
            else
            {
                return punten;
            }
        }
    }


    class Omdraaien : IMoves
    {
        public string naam { get => "Omdraaien"; }
        Random rnd = new Random();
        int kans = 60;
        int punten = 5;
        public int Move()
        {
            int kansgetal = rnd.Next(100);
            if (kansgetal <= kans)
            {
                return punten;
            }
            return 0;
        }
    }
    class Eenbeen : IMoves
    {
        public string naam { get => "Eenbeen"; }
        Random rnd = new Random();

        int kans = 40;
        int punten = 12;
        public int Move()
        {
            int kansgetal = rnd.Next(100);
            if (kansgetal <= kans)
            {
                return punten;
            }
            return 0;
        }
    }
    class Eenhand : IMoves
    {
        public string naam { get => "Eenhand"; }
        Random rnd = new Random();

        int kans = 45;
        int punten = 9;
        public int Move()
        {
            int kansgetal = rnd.Next(100);
            if (kansgetal <= kans)
            {
                return punten;
            }
            return 0;
        }
    }

    public static class MoveCollection
    {
        public static List<IMoves> GetWillekeurigeMoves()
        {
            List<IMoves> moves = new List<IMoves>();
            Random rnd = new Random();
            IMoves[] _possibleMoves = new IMoves[] { new Jump(), new Omdraaien(), new Eenbeen(), new Eenhand() };

            int max = rnd.Next(1, _possibleMoves.Length + 1);

            for (int i = 0; i < max; i++)
            {
                moves.Add(_possibleMoves[i]);
            }

            return moves;
        }
    }
}
