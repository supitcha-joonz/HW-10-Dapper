using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestProblem.Models;
using RequestProblem.Services;

namespace RequestProblem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemsController : ControllerBase
    {
        private readonly IProblemsService _problemsService;

        public ProblemsController(IProblemsService problemsService)
        {
            _problemsService = problemsService;
        }

        [HttpGet]
        public IEnumerable<Problems> GetAllProblems()
        {
            return _problemsService.GetAllProblems();
        }

        [HttpGet("{id}")]
        public Problems GetByIdProblems(int id)
        {

            return _problemsService.GetByIdProblems(id);
        }

        [HttpPost]
        public void AddProblems(Problems problems)
        {
            _problemsService.AddProblems(problems); 
        }

        [HttpPut("{id}")]
        public void UpdateProblems(Problems problems)
        {
            _problemsService.UpdateProblems(problems);
        }

        [HttpDelete("{id}")]
        public void DeleteProblems(int id)
        {
            _problemsService?.DeleteProblems(id);   
        }
    }
}
