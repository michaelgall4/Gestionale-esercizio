using GestionaleLibrary.People;
using System.Data.SqlClient;


namespace GestionaleLibrary.Persister
{
    public class TeacherPersister
    {
        public readonly string ConnectionString;
        public TeacherPersister(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public bool AddTeacher(Teacher teacher)
        {
            var sql = @"INSERT INTO [dbo].[Teacher](
                                    [IdPerson],
                                    [Matricola],
                                    [DataAssunzione])
                              Values
                                    (@IdPerson,
                                     @Matricola,
                                     @DataAssunzione)
                              SELECT @@IDENTITY AS 'Identity'";


            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@IdPerson", teacher.Id);
            command.Parameters.AddWithValue("@Matricola", teacher.Matricola);
            command.Parameters.AddWithValue("@DataAssunzione", teacher.DataAssunzione);
            return command.ExecuteNonQuery() > 0;
        }
    }
}
