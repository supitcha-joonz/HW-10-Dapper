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

        public IEnumerable<Problems> GetAll()
        {
            var problems = _problemsRepository.GetAll();
            var resp = problems.OrderByDescending(m => m.ProblemName);
            return resp;
        }

        public Problems GetById(int id)
        {
            return _problemsRepository.GetById(id);
        }

        public int Add(Problems problems)
        {
            return _problemsRepository.Add(problems);
        }

        public int Update(Problems problems)
        {
            return _problemsRepository.Update(problems);
        }

        public int Delete(int id)
        {
            return _problemsRepository.Delete(id);
        }

      

       
    }
}
