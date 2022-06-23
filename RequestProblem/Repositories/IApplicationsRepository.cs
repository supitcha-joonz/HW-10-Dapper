using RequestProblem.Models;

namespace RequestProblem.Repositories
{
    public interface IApplicationsRepository
    {
        IEnumerable<Applications> GetAllApplications();

        Applications GetByIdApplications(int id);
        void AddApplications(Applications applications);
        void UpdateApplications(Applications applications);
        void DeleteApplications(int id);
    }
}
