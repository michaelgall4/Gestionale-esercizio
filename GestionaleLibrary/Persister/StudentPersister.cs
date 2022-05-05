using GestionaleLibrary.People;
using System.Data.SqlClient;

namespace GestionaleLibrary.Persister
{
    public class StudentPersister
    {
        public readonly string ConnectionString;
        public StudentPersister(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public int AddStudent(Student student)
        {
            var sql = @"INSERT INTO [dbo].[Student](
                                    [IdPerson],
                                    [Matricola],
                                    [DataIscrizione])
                              Values
                                    (@IdPerson,
                                     @Matricola,
                                     @DataIscrizione)
                              SELECT @@IDENTITY AS 'Identity'";


            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdPerson", student.Id);
            command.Parameters.AddWithValue("@Matricola", student.Matricola);
            command.Parameters.AddWithValue("@DataIscrizione", student.DataIscrizione);
            return Convert.ToInt32(command.ExecuteScalar());
        }


        //public bool UpdateStudent(Student student)
        //{
        //    var sql = @"UPDATE [dbo].[Student]
        //                  SET [Name] = @Name,
        //                      [Surname] = @Surname,
        //                      [BirthDay] = @BirthDay,
        //                      [Gender] = @Gender,
        //                      [Address] = @Address
        //                  WHERE @IdStudente = IdStudente";
        //    using var connection = new SqlConnection(ConnectionString);
        //    connection.Open();
        //    using var command = new SqlCommand(sql, connection);
        //    command.Parameters.AddWithValue("@Id", person.Id);
        //    command.Parameters.AddWithValue("@Name", person.Name);
        //    command.Parameters.AddWithValue("@Surname", person.Surname);
        //    command.Parameters.AddWithValue("@BirthDay", person.BirthDay);
        //    command.Parameters.AddWithValue("@Gender", person.Gender);
        //    command.Parameters.AddWithValue("@Address", person.Address);
        //    return command.ExecuteNonQuery() > 0;
        //}


        //public void Delete(int IdStudente)
        //{
        //    var sql = @"DELETE FROM [dbo].[Student]
        //                WHERE IdStudente = @IdStudente";
        //    var connection = new SqlConnection(ConnectionString);
        //    connection.Open();
        //    var command = new SqlCommand(sql, connection);
        //    command.Parameters.AddWithValue("@IdStudente", IdStudente);
        //    command.ExecuteNonQuery();
        //}

        //public List<Person> GetPerson(int Id)
        //{
        //    var sql = @"SELECT [Id],
        //                       [Name],
        //                       [Surname],
        //                       [BirthDay],
        //                       [Gender],
        //                       [Address]
        //                FROM [Gestionale].[dbo].[Person]
        //                WHERE Id = @Id";

        //    var listResult = new List<Person>();

        //    using var connection = new SqlConnection(ConnectionString);
        //    connection.Open();
        //    using var command = new SqlCommand(sql, connection);
        //    command.Parameters.AddWithValue("@Id", Id);
        //    var reader = command.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        var student = new Student()
        //        {
        //            Id = Convert.ToInt32(reader["Id"]),
        //            Name = reader["Name"].ToString(),
        //            Surname = reader["Surname"].ToString(),
        //            BirthDay = Convert.ToDateTime(reader["Birthday"]),
        //            Gender = reader["Gender"].ToString(),
        //            Address = reader["Address"].ToString()
        //        };
        //        listResult.Add(student);

        //    }
        //    return listResult;
        //}

    }
}
