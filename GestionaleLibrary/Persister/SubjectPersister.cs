using GestionaleLibrary.School;
using System.Data.SqlClient;

namespace GestionaleLibrary.Persister
{
    public class SubjectPersister
    {
        public readonly string ConnectionString;
        public SubjectPersister(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public bool AddSubject(Subject subject)
        {
            var sql = @"INSERT INTO [dbo].[Subject](
                                    [Name],
                                    [Description],
                                    [Credits],
                                    [Hours])
                              Values
                                    (
                                     @Name,
                                     @Description,
                                     @Credits,
                                     @Hours)
                              SELECT @@IDENTITY AS 'Identity'";


            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", subject.Name);
            command.Parameters.AddWithValue("@Description", subject.Description);
            command.Parameters.AddWithValue("@Credits", subject.Credits);
            command.Parameters.AddWithValue("@Hours", subject.Hours);
            return command.ExecuteNonQuery() > 0;
        }


        public bool UpdateSubject(Subject subject)
        {
            var sql = @"UPDATE [dbo].[Subject]
                          SET [Name] = @Name,
                              [Description] = @Description,
                              [Credits] = @Credits,
                              [Hours] = @Hours
                          WHERE @IdSubject = IdSubject";
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdSubject", subject.IdSubject);
            command.Parameters.AddWithValue("@Name", subject.Name);
            command.Parameters.AddWithValue("@Description", subject.Description);
            command.Parameters.AddWithValue("@Credits", subject.Credits);
            command.Parameters.AddWithValue("@Hours", subject.Hours);
            return command.ExecuteNonQuery() > 0;
        }


        public bool DeleteSubject(int IdSubject)
        {
            var sql = @"DELETE FROM [dbo].[Subject]
                        WHERE IdSubject = @IdSubject";
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdSubject", IdSubject);
            return command.ExecuteNonQuery() > 0;
        }

        public List<Subject> GetSubject(int IdSubject)
        {
            var sql = @"SELECT [IdSubject],
                               [Name],
                               [Description],
                               [Credits],
                               [Hours],
                        FROM [dbo].[Subject]
                        WHERE IdSubject = @IdSubject";

            var listResult = new List<Subject>();

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdSubject", IdSubject);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var subject = new Subject()
                {
                    IdSubject = Convert.ToInt32(reader["IdSubject"]),
                    Name = reader["Name"].ToString(),
                    Description = reader["Description"].ToString(),
                    Credits = Convert.ToInt32(reader["Credtis"]),
                    Hours = Convert.ToInt32(reader["Hours"])
                };
                listResult.Add(subject);

            }
            return listResult;
        }
    }
}
