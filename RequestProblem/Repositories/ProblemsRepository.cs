using Dapper;
using Microsoft.Data.SqlClient;
using RequestProblem.Models;

namespace RequestProblem.Repositories
{
    public class ProblemsRepository : IProblemsRepository
    {
        
        private readonly IConfiguration _configuration;
        private readonly ProblemMgmtContext _problemMgmtContext;

        public ProblemsRepository(ProblemMgmtContext problemMgmtContext, IConfiguration configuration)
        {
            _problemMgmtContext = problemMgmtContext;
            _configuration = configuration;
        }

        public IEnumerable<Problems> GetAllProblems()
        {
            using (var db = new SqlConnection(_configuration.GetSection("ConnectionStrings:ConnectionString").Value)) {

                var sqlCommand = string.Format(@"SELECT * FROM [Problems]");
                return db.Query<Problems>(sqlCommand).ToList();
            }
               
        }

        public Problems GetByIdProblems(int id)
        {
            using (var db = new SqlConnection(_configuration.GetSection("ConnectionStrings:ConnectionString").Value))
            {

                var sqlCommand = string.Format(@"SELECT * FROM [Problems] WHERE Id = @Id");
                return db.Query<Problems>(sqlCommand, new { Id = id }).FirstOrDefault();
            }
        }

        public int AddProblems(Problems problems)
        {
            using (var db = new SqlConnection(_configuration.GetSection("ConnectionStrings:ConnectionString").Value))
            {
                var sqlCommand = string.Format(@"INSERT INTO [Problems]
                                                           ([ProblemName]
                                                           ,[Description]
                                                           ,[ApplicationId])
                                                     VALUES
                                                           (@ProblemName
                                                           ,@Description
                                                           ,@ApplicationId)");
                return db.Execute(sqlCommand, ParameterMapping(problems));
            }
        }

        public int UpdateProblems(Problems problems)
        {
            using (var db = new SqlConnection(_configuration.GetSection("ConnectionStrings:ConnectionString").Value))
            {
                var sqlCommand = string.Format(@"UPDATE [Problems]
                                               SET [ProblemName] = @ProblemName
                                                  ,[Description] = @Description
                                                  ,[ApplicationId] = @ApplicationId
                                             WHERE [Id] = @Id");
                return db.Execute(sqlCommand, ParameterMapping(problems));
            }
        }

        public int DeleteProblems(int id)
        {
            using (var db = new SqlConnection(_configuration.GetSection("ConnectionStrings:ConnectionString").Value))
            {
                var sqlCommand = string.Format(@"DELETE FROM [Problems] WHERE [id] = @Id");
                return db.Execute(sqlCommand, new { Id = id});
            }
        }

        private Object ParameterMapping(Problems problems) {
            return new
            {
                Id = problems.Id,
                ProblemName = problems.ProblemName,
                Description = problems.Description,
                ApplicationId = problems.ApplicationId
            };
        }

        

        
    }
}
