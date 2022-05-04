﻿using GestionaleMyLibrary.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleMyLibrary.School
{
    public class Subject : Teacher
    {
        public int IdSubject { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Credits { get; set; }
        public int Hours { get; set; }
    }
}
