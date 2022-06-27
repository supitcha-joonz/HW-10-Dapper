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
        }

     

        public override async Task<int> Add(Problems problems)
        {
            using (var db = new SqlConnection(connectionStrings))
            {
                var sqlCommand = string.Format(@"INSERT INTO [Problems]
                                                           ([ProblemName]
                                                           ,[Description]
                                                           ,[ApplicationId])
                                                     VALUES
                                                           (@ProblemName
                                                           ,@Description
                                                           ,@ApplicationId)");
                return await db.ExecuteAsync(sqlCommand, ParameterMapping(problems));
            }
        }

        public override async Task<int> Update(Problems problems)
        {
            using (var db = new SqlConnection(connectionStrings))
            {
                var sqlCommand = string.Format(@"UPDATE [Problems]
                                               SET [ProblemName] = @ProblemName
                                                  ,[Description] = @Description
                                                  ,[ApplicationId] = @ApplicationId
                                             WHERE [Id] = @Id");
                return await db.ExecuteAsync(sqlCommand, ParameterMapping(problems));
            }
        }

        public override async Task<int> Delete(int id)
        {
            using (var db = new SqlConnection(connectionStrings))
            {
                var sqlCommand = string.Format(@"DELETE FROM [Problems] WHERE [id] = @Id");
                return await db.ExecuteAsync(sqlCommand, new { Id = id});
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
