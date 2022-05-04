using GestionaleLibrary.People;
using System.Data.SqlClient;
using GestionaleLibrary;
using GestionaleLibrary.Persister;
using GestionaleLibrary.School;

namespace Gestionale.Handler
{
    public class SubjectHandler
    {
        private readonly string connectionString = "Server=ACADEMYNETPD03;DataBase=Gestionale;Trusted_Connection=true";

        public bool AddMateria()
        {
            var subject = new Subject
            {
                IdSubject = 1,
                Name = "Matetamtica",
                Description = "non lo so",
                Credits = 5,
                Hours = 13
            };

            var subjectPersister = new SubjectPersister(connectionString);
            return subjectPersister.Add(subject);
        }
    }
}
