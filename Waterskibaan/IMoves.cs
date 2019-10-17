using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public interface IMoves
    {
        int Move();
        
    }
    class Jump : IMoves
    {
        Random rnd = new Random();
        
        int kans = 70;
        int punten;
        public int Move()
        {
            int kansgetal = rnd.Next(100);
            if(kansgetal <= kans)
            {
                punten = punten + 2;
                return punten;
            }
            return 0;
        }
    }
    class Omdraaien : IMoves
    {
        Random rnd = new Random();

        int kans = 60;
        int punten;
        public int Move()
        {
            int kansgetal = rnd.Next(100);
            if (kansgetal <= kans)
            {
                punten = punten + 3;
                return punten;
            }
            return 0;
        }
    }
    class Eenbeen : IMoves
    {
        Random rnd = new Random();

        int kans = 40;
        int punten;
        public int Move()
        {
            int kansgetal = rnd.Next(100);
            if (kansgetal <= kans)
            {
                punten = punten + 4;
                return punten;
            }
            return 0;
        }
    }
    class Eenhand : IMoves
    {
        Random rnd = new Random();

        int kans = 45;
        int punten;
        public int Move()
        {
            int kansgetal = rnd.Next(100);
            if (kansgetal <= kans)
            {
                punten = punten + 6;
                return punten;
            }
            return 0;
        }
    }

    public static class MoveCollection
    {
        private static List<IMoves> _possibleMoves = new List<IMoves> { new Jump(), new Omdraaien(), new Eenbeen(), new Eenhand()};
        public static List<IMoves> GetWillekeurigeMoves()
        {
            List<IMoves> moves = new List<IMoves>();
            Random rnd = new Random();

            int max = rnd.Next(1, _possibleMoves.Count + 1);

            for (int i = 0; i < max; i++)
            {
                moves.Add(_possibleMoves[i]);
            }

            return moves;
        }

    }


}
