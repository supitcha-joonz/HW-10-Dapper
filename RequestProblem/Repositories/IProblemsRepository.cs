using RequestProblem.Models;

namespace RequestProblem.Repositories
{
    public interface IProblemsRepository
    {
        Task<IEnumerable<Problems>> GetAll();

        Task<Problems> GetById(int id);
        Task<int> Add(Problems problems);
        Task<int> Update(Problems problems);
        Task<int> Delete(int id);
    }
}
