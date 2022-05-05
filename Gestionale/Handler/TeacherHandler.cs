using GestionaleLibrary.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionaleLibrary.Persister;

namespace Gestionale.Handler
{
    public class TeacherHandler
    {
        private readonly string connectionString = "Server=ACADEMYNETPD03\\SQLEXPRESS;DataBase=Gestionale;Trusted_Connection=true";



        public bool AddDocente()
        {
            var teacher = new Teacher
            {
                Id = 16,
                Matricola = "ZYX",
                DataAssunzione = new DateTime(2020, 09, 10),


            };

            var teacherPersister = new TeacherPersister(connectionString);
            return teacherPersister.AddTeacher(teacher)>0;
        }
    }
}

