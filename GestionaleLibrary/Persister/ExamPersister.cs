using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleLibrary.Persister
{
    public class ExamPersister
    {
        public readonly string ConnectionString;
        public ExamPersister(string connectionString)
        {
            ConnectionString = connectionString;
        }

    }
}
