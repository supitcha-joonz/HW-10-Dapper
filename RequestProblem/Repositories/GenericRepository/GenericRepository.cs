using Dapper;
using Microsoft.Data.SqlClient;
using RequestProblem.Models;

namespace RequestProblem.Repositories.GenericRepository
{

   
    public abstract class GenericRepository<T>
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionStrings = "";

        public GenericRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionStrings = _configuration.GetSection("ConnectionStrings:ConnectionString").Value;
        }

        public IEnumerable<T> GetAllProblems()
        {
            using (var db = new SqlConnection(connectionStrings))
            {
                var className = typeof(T).Name;
                var sqlCommand = $"SELECT * FROM {className}";
                return db.Query<T>(sqlCommand).ToList();
            
            }
        }

        public T GetByIdProblems(int id)
        {
            using (var db = new SqlConnection(connectionStrings))
            {
                var className = typeof(T).Name;
                var sqlCommand = $"SELECT * FROM {className} WHERE [Id] = @Id";
                return db.Query<T>(sqlCommand, new { Id = id}).FirstOrDefault();

            }
        }

        public abstract int AddProblems(T model);
        public abstract int UpdateProblems(T model);
        public abstract int DeleteProblems(int id);

    }
}
