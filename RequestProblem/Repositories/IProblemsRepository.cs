using RequestProblem.Models;

namespace RequestProblem.Repositories
{
    public interface IProblemsRepository
    {
        IEnumerable<Problems> GetAllProblems();

        Problems GetByIdProblems(int id);
        int AddProblems(Problems problems);
        int UpdateProblems(Problems problems);
        int DeleteProblems(int id);
    }
}
