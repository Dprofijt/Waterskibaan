using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public abstract class Wachtrij
    {
        public int MAX_LENGTE_RIJ;

        private Queue<Sporter> _queue = new Queue<Sporter>();

        public abstract bool Aantal(int aantal);

        public void SporterNeemPlaatsInRij(Sporter sporter)
        {
            if (Aantal(_queue.Count + 1))
            {
                _queue.Enqueue(sporter);
            }
            else
            {
                throw new Exception("De wachtrij zit vol!");
            }
        }

        public List<Sporter> GetAlleSporters()
        {
            return _queue.ToList();
        }

        public List<Sporter> SportersVerlatenRij(int aantal)
        {
            
            List<Sporter> sporters = new List<Sporter>();
            if (aantal < _queue.Count)
            {
                for (int i = 0; i < aantal; i++)
                {
                    sporters.Add(_queue.Dequeue());
                }
            }

            return sporters;
        }

        public override string ToString()
        {
            return $"Wachtrij: {_queue.Count} sporters";
        }
    }
}
