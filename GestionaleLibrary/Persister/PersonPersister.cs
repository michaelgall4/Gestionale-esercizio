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

        public int AddPerson(Person person)
        {
            var sql = @"INSERT INTO [dbo].[Person](
                                    [Name],
                                    [Surname],
                                    [BirthDay],
                                    [Gender],
                                    [Address])
                              Values
                                    (
                                     @Name,
                                     @Surname,
                                     @BirthDay,
                                     @Gender,
                                     @Address)
                              SELECT @@IDENTITY AS 'Identity'";


            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", person.Name);
            command.Parameters.AddWithValue("@Surname", person.Surname);
            command.Parameters.AddWithValue("@BirthDay", person.BirthDay);
            command.Parameters.AddWithValue("@Gender", person.Gender);
            command.Parameters.AddWithValue("@Address", person.Address);
            return Convert.ToInt32(command.ExecuteScalar());
        }


        public void UpdatePerson(Person person)
        {
            var sql = @"UPDATE [dbo].[Person]
                          SET [Name] = @Name,
                              [Surname] = @Surname,
                              [BirthDay] = @BirthDay,
                              [Gender] = @Gender,
                              [Address] = @Address
                          WHERE Id = @Id";
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", person.Id);
            command.Parameters.AddWithValue("@Name", person.Name);
            command.Parameters.AddWithValue("@Surname", person.Surname);
            command.Parameters.AddWithValue("@BirthDay", person.BirthDay);
            command.Parameters.AddWithValue("@Gender", person.Gender);
            command.Parameters.AddWithValue("@Address", person.Address);
            command.ExecuteNonQuery();
        }


        public bool DeletePerson(int Id)
        {
            var sql = @"DELETE FROM [dbo].[Person]
                        WHERE Id = @Id";
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", Id);
            return command.ExecuteNonQuery() > 0;
        }

        public List<Person> GetPerson(int Id)
        {
            var sql = @"SELECT [Id],
                               [Name],
                               [Surname],
                               [BirthDay],
                               [Gender],
                               [Address]
                        FROM [dbo].[Person]
                        WHERE Id = @Id";

            var listResult = new List<Person>();

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", Id);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var person = new Person()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Surname = reader["Surname"].ToString(),
                    BirthDay = Convert.ToDateTime(reader["Birthday"]),
                    Gender = reader["Gender"].ToString(),
                    Address = reader["Address"].ToString()
                };
                listResult.Add(person);

            }
            return listResult;
        }


    }
}
