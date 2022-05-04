using GestionaleLibrary.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleLibrary.School
{
    public class ExamDetails : Student
    {
        public int IdExamDetails { get; set; }
        public int IdExam { get; set; }
    }
}
