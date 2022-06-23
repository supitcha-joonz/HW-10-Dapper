using RequestProblem.Models;

namespace RequestProblem.Repositories
{
    public interface IProblemsRepository
    {
        IEnumerable<Problems> GetAll();

        Problems GetById(int id);
        int Add(Problems problems);
        int Update(Problems problems);
        int Delete(int id);
    }
}
