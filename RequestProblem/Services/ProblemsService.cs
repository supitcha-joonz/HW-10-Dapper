using RequestProblem.Models;
using RequestProblem.Repositories;

namespace RequestProblem.Services
{
    public class ProblemsService : IProblemsService
    {
        private readonly IProblemsRepository _problemsRepository;

        public ProblemsService(IProblemsRepository problemsRepository)
        {
            _problemsRepository = problemsRepository;
        }

        public async Task<IEnumerable<Problems>> GetAll()
        {
            var problems = await _problemsRepository.GetAll();
            var resp = problems.OrderByDescending(m => m.ProblemName);
            return resp;
        }

        public async Task<Problems> GetById(int id)
        {
            return await _problemsRepository.GetById(id);
        }

        public async Task<bool> Add(Problems problems)
        {
            //validate dupicate
            var problemList = await _problemsRepository.GetAll();
            var isDupicate = problemList.Where(m => m.ProblemName == problems.ProblemName);
            if (isDupicate.Count() > 0) {
                throw new Exception("Error Problem is Dupicate");
            }
            return await _problemsRepository.Add(problems) > 0;
        }

        public async Task<bool> Update(Problems problems)
        {
            var problemList = await _problemsRepository.GetAll();
            var isDupicate = problemList.Where((m) => m.ProblemName == problems.ProblemName && m.Id != problems.Id);
            if (isDupicate.Count() > 0)
            {
                throw new Exception("Error Problem is Dupicate");
            }
            return await _problemsRepository.Update(problems) > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var problem = await _problemsRepository.GetById(id);
            if (problem == null) {
                throw new Exception("Error Problem not exist");
            }
            return await _problemsRepository.Delete(id) > 0;
        }

      

       
    }
}
