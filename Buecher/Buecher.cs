﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buecher
{
    public abstract class Buch
    {
        //Konstruktor
        public Buch()
        {

        }

        public string? titel { get; set; }
        public string? autor { get; set; }

    }
}
