using GestionaleLibrary.People;
using GestionaleLibrary.Persister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionale.Handler
{
    public class StudentHandler
    {
        private readonly string connectionString = "Server=ACADEMYNETPD03\\SQLEXPRESS;DataBase=Gestionale;Trusted_Connection=true";



        public bool AddStudente()
        {
            var student = new Student
            {
                Id = 1,
                Matricola = "XYZ",
                DataIscrizione = new DateTime(2020,09,10),
                
                
            };

            var studentPersister = new StudentPersister(connectionString);
            return studentPersister.AddStudent(student);
        }
    }
}
