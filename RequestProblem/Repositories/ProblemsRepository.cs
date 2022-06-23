using Dapper;
using Microsoft.Data.SqlClient;
using RequestProblem.Models;
using RequestProblem.Repositories.GenericRepository;

namespace RequestProblem.Repositories
{
    public class ProblemsRepository : GenericRepository<Problems>, IProblemsRepository
    {
        
        private readonly IConfiguration _configuration;
    

        public ProblemsRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

     

        public override int Add(Problems problems)
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

        public override int Update(Problems problems)
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

        public override int Delete(int id)
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
