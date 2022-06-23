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

        public IEnumerable<Problems> GetAllProblems()
        {
            var problems = _problemsRepository.GetAllProblems();
            var resp = problems.OrderByDescending(m => m.ProblemName);
            return resp;
        }

        public Problems GetByIdProblems(int id)
        {
            return _problemsRepository.GetByIdProblems(id);
        }

        public void AddProblems(Problems problems)
        {
            _problemsRepository.AddProblems(problems);
        }

        public void UpdateProblems(Problems problems)
        {
            _problemsRepository.UpdateProblems(problems);
        }

        public void DeleteProblems(int id)
        {
            _problemsRepository.DeleteProblems(id);
        }

      

       
    }
}
