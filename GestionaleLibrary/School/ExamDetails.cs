using GestionaleLibrary.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleLibrary.School
{
    public class ExamDetails : Exam
    {
        public int IdExamDetails { get; set; }
        public int IdStudent { get; set; }
        
    }
}
