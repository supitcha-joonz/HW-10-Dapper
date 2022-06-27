using RequestProblem.Models;
using RequestProblem.Repositories;

namespace RequestProblem.Services
{
    public class ApplicationsService : IApplicationsService
    {
        private readonly IApplicationsRepository _applicationsRepository;

        public ApplicationsService(IApplicationsRepository applicationsRepository)
        {
            _applicationsRepository = applicationsRepository;
        }

        public async Task<IEnumerable<Applications>> GetAll()
        {
            var applications = await _applicationsRepository.GetAll();
            var resp = applications.OrderByDescending(m => m.ApplicationName);
            return resp;
        }

        public async Task<Applications> GetById(int id)
        {
            return await _applicationsRepository.GetById(id);
        }

        public async Task<bool> Add(Applications applications)
        {
            var applicationList = await _applicationsRepository.GetAll();
            var isDupicate = applicationList.Where(m => m.ApplicationName == applications.ApplicationName);
            if (isDupicate.Count() > 0)
            {
                throw new Exception("Error Application is Dupicate");
            }
            return await _applicationsRepository.Add(applications) > 0;
        }

        public async Task<bool> Update(Applications applications)
        {
            var applicationList = await _applicationsRepository.GetAll();
            var isDupicate = applicationList.Where(m => m.ApplicationName == applications.ApplicationName && m.Id != applications.Id);
            if (isDupicate.Count() > 0)
            {
                throw new Exception("Error Application is Dupicate");
            }
            return await _applicationsRepository.Update(applications) > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var application = await _applicationsRepository.GetById(id);
            if (application == null)
            {
                throw new Exception("Error Application not exist");
            }
            return await _applicationsRepository.Delete(id) > 0;
        }

       

        
    }
}
