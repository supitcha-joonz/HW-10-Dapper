using Dapper;
using Microsoft.Data.SqlClient;
using RequestProblem.Models;
using RequestProblem.Repositories.GenericRepository;

namespace RequestProblem.Repositories
{
    public class ApplicationsRepository : GenericRepository<Applications> , IApplicationsRepository
    {

        private readonly IConfiguration _configuration;
        public ApplicationsRepository(IConfiguration configuration) : base(configuration)
        {
            
        }

        public override async Task<int> Add(Applications applications)
        {
            using (var db = new SqlConnection(connectionStrings))
            {
                var sqlCommand = string.Format(@"INSERT INTO [Applications]
                                                                   ([ApplicationName]
                                                                   ,[Description])
                                                             VALUES
                                                                   (@ApplicationName
                                                                   ,@Description)");

                return await db.ExecuteAsync(sqlCommand, ParameterMapping(applications));
            }
        }

        public override async Task<int> Update(Applications applications)
        {
            using (var db = new SqlConnection(connectionStrings))
            {
                var sqlCommand = string.Format(@"UPDATE [Applications]
                                                   SET [ApplicationName] = @ApplicationName
                                                      ,[Description] = @Description
                                                 WHERE [Id] = @Id");

                return await db.ExecuteAsync(sqlCommand, ParameterMapping(applications));
            }
        }

        public override async Task<int> Delete(int id)
        {
            using (var db = new SqlConnection(connectionStrings))
            {
                var sqlCommand = string.Format(@"DELETE FROM [Applications] WHERE [id] = @Id");
                return await db.ExecuteAsync(sqlCommand, new { Id = id });
            }
        }

      

        private Object ParameterMapping(Applications applications)
        {
            return new
            {
                Id = applications.Id,
                ApplicationName = applications.ApplicationName,
                Description = applications.Description
            };
        }
    }
}
