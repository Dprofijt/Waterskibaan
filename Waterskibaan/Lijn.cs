﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan
{
    public class Lijn
    {
        public int PositieOpDeKabel { get; set; }
        public Sporter Sporter { get; set; }

        public Lijn()
        {
            PositieOpDeKabel = 0;
        }
    }
}