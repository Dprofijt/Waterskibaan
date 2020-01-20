using System;
using System.Collections.Generic;
using System.Linq;

namespace Waterskibaan
{
    public abstract class Wachtrij
    {
        public virtual int MAX_LENGTE_RIJ { get; }

        private Queue<Sporter> _queue = new Queue<Sporter>();

        public void SporterNeemPlaatsInRij(Sporter sporter)
        {
            if (_queue.Count < MAX_LENGTE_RIJ)
            {
                _queue.Enqueue(sporter);
            }
        }

        public List<Sporter> GetAlleSporters()
        {
            return _queue.ToList<Sporter>();
        }

        public List<Sporter> SportersVerlatenRij(int aantal)
        {
            List<Sporter> sporters = new List<Sporter>();
            aantal = Math.Min(aantal, _queue.Count);
            for (int i = 0; i < aantal; i++)
            {
                sporters.Add(_queue.Dequeue());
            }
            return sporters;
        }

        public override string ToString()
        {
            return $"Wachtrij: {_queue.Count} sporters";
        }
    }
}
