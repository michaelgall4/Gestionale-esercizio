﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionale
{
    internal class Student : Person
    { 
        public int IdStudent { get; set; }
        public string Matricola { get; set; }
        public DateTime DataIscrizione { get; set; }
    }
}
