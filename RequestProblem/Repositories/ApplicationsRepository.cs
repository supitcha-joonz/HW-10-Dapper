using RequestProblem.Models;

namespace RequestProblem.Repositories
{
    public class ApplicationsRepository : IApplicationsRepository
    {
        private readonly ProblemMgmtContext _problemMgmtContext;

        public ApplicationsRepository(ProblemMgmtContext problemMgmtContext)
        {
            _problemMgmtContext = problemMgmtContext;

        }

        public IEnumerable<Applications> GetAllApplications()
        {
            return _problemMgmtContext.Applications.ToList();
        }

        public Applications GetByIdApplications(int id)
        {
            return _problemMgmtContext.Applications.Find(id);
        }

        public void AddApplications(Applications applications)
        {
            _problemMgmtContext.Applications.Add(applications);
            _problemMgmtContext.SaveChanges();
        }

        public void UpdateApplications(Applications applications)
        {
            _problemMgmtContext.Entry(applications).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _problemMgmtContext.SaveChanges();
        }

        public void DeleteApplications(int id)
        {
            var application = _problemMgmtContext.Applications.Find(id);
            _problemMgmtContext.Applications.Remove(application);
            _problemMgmtContext.SaveChanges();
        }

        

        
    }
}
