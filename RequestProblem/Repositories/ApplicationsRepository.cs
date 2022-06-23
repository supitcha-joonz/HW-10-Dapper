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
            _configuration = configuration;
        }

        public override int Add(Applications applications)
        {
            using (var db = new SqlConnection(_configuration.GetSection("ConnectionStrings:ConnectionString").Value))
            {
                var sqlCommand = string.Format(@"INSERT INTO [Applications]
                                                                   ([ApplicationName]
                                                                   ,[Description])
                                                             VALUES
                                                                   (@ApplicationName
                                                                   ,@Description)");

                return db.Execute(sqlCommand, ParameterMapping(applications));
            }
        }

        public override int Update(Applications applications)
        {
            using (var db = new SqlConnection(_configuration.GetSection("ConnectionStrings:ConnectionString").Value))
            {
                var sqlCommand = string.Format(@"UPDATE [Applications]
                                                   SET [ApplicationName] = @ApplicationName
                                                      ,[Description] = @Description
                                                 WHERE [Id] = @Id");

                return db.Execute(sqlCommand, ParameterMapping(applications));
            }
        }

        public override int Delete(int id)
        {
            using (var db = new SqlConnection(_configuration.GetSection("ConnectionStrings:ConnectionString").Value))
            {
                var sqlCommand = string.Format(@"DELETE FROM [Applications] WHERE [id] = @Id");
                return db.Execute(sqlCommand, new { Id = id });
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
