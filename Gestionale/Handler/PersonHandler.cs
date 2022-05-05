using GestionaleLibrary.People;
using System.Data.SqlClient;
using GestionaleLibrary;
using GestionaleLibrary.Persister;

namespace Gestionale
{
    
    public class PersonHandler
    {
        private readonly string connectionString = "Server=ACADEMYNETPD03\\SQLEXPRESS;DataBase=Gestionale;Trusted_Connection=true";



        public bool AddPersona()
        {
            var person = new Person
            {

                Name = "Sergio",
                Surname = "Matterella",
                BirthDay = new DateTime(1934, 08, 15),
                Gender = "Male",
                Address = "Via Italia"
            };

            var personPersister = new PersonPersister(connectionString);
            return personPersister.AddPerson(person)>0;
        }

        public bool DeletePersona(int Id)
        {
            var personPersister = new PersonPersister(connectionString);
            return personPersister.DeletePerson(15);
        }
    }
}
