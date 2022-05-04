using GestionaleMyLibrary.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleMyLibrary.School
{
    public class Class : Student
    {
        public int IdClass { get; set; }
        public int IdLesson { get; set; }
    }
}
