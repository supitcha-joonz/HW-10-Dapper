using RequestProblem.Models;

namespace RequestProblem.Services
{
    public interface IProblemsService
    {
        IEnumerable<Problems> GetAll();

        Problems GetById(int id);
        int Add(Problems problems);
        int Update(Problems problems);
        int Delete(int id);
    }
}
