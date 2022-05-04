using GestionaleLibrary.People;
using System.Data.SqlClient;
using GestionaleLibrary;
using GestionaleLibrary.Persister;

namespace Gestionale
{
    
    public class PersonHandler
    {
        private readonly string connectionString = "Server=ACADEMYNETPD03;DataBase=Gestionale;Trusted_Connection=true";


        public bool AddPersona()
        {
            var person = new Person
            {

                Name = "Mario",
                Surname = "Draghi",
                BirthDay = new DateTime(1947, 07, 12),
                Gender = "Male",
                Address = "Via Italia"
            };

            var personPersister = new PersonPersister(connectionString);
            return personPersister.Add(person);
        }
    }
}
