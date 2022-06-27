using RequestProblem.Models;

namespace RequestProblem.Services
{
    public interface IProblemsService
    {
        Task<IEnumerable<Problems>> GetAll();

        Task<Problems> GetById(int id);
        Task<bool> Add(Problems problems);
        Task<bool> Update(Problems problems);
        Task<bool> Delete(int id);
    }
}
