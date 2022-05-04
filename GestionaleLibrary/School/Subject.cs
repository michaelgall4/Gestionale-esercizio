using GestionaleLibrary.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleLibrary.School
{
    public class Subject 
    {
        public int IdSubject { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Credits { get; set; }
        public int Hours { get; set; }
    }
}
