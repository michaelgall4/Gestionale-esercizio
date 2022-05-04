using GestionaleLibrary.People;
using System.Data.SqlClient;


namespace GestionaleLibrary.Persister
{
    public class PersonPersister
    {
        public readonly string ConnectionString;
        public PersonPersister(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void Add(Person person)
        {
            var sql = @"INSERT INTO [Gestionale].[dbo].[Person](
                                    [Id],
                                    [Name],
                                    [Surname],
                                    [BirthDay],
                                    [Gender])
                              Values
                                    (@Id,
                                     @Name,
                                     @Surname,
                                     @BirthDay,
                                     @Gender)";


            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", person.Id);
            command.Parameters.AddWithValue("@Name", person.Name);
            command.Parameters.AddWithValue("@Surname", person.Surname);
            command.Parameters.AddWithValue("@BirthDay", person.Birthday);
            command.Parameters.AddWithValue("@Gender", person.Gender);
            command.ExecuteNonQuery();
        }


        public void Update(Person person)
        {
            var sql = @"UPDATE [Gestionale].[dbo].[Person]
                          SET [Name] = @Name,
                              [Surname] = @Surname,
                              [BirthDay] = @BirthDay,
                              [Gender] = @Gender
                          WHERE @Id = Id";
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", person.Id);
            command.Parameters.AddWithValue("@Name", person.Name);
            command.Parameters.AddWithValue("@Surname", person.Surname);
            command.Parameters.AddWithValue("@BirthDay", person.Birthday);
            command.Parameters.AddWithValue("@Gender", person.Gender);
            command.ExecuteNonQuery();
        }


        public void Delete(int IdPerson)
        {
            var sql = @"DELETE FROM [Gestionale].[dbo].[Person]
                        WHERE Id = @Id";
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", IdPerson);
            command.ExecuteNonQuery();
        }


    }
}
