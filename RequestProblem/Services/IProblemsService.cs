using RequestProblem.Models;

namespace RequestProblem.Services
{
    public interface IProblemsService
    {
        IEnumerable<Problems> GetAllProblems();

        Problems GetByIdProblems(int id);
        void AddProblems(Problems problems);
        void UpdateProblems(Problems problems);
        void DeleteProblems(int id);
    }
}
