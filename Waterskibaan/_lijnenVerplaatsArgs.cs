using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class _lijnenVerplaatsArgs : EventArgs
    {
        public Sporter Sporter { get; set; }
        public LinkedList<Lijn> _lijnen { get; set; }
    }
}
