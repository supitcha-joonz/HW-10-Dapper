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
        public IEnumerable<Problems> GetAll()
        {
            return _problemsService.GetAll();
        }

        [HttpGet("{id}")]
        public Problems GetById(int id)
        {

            return _problemsService.GetById(id);
        }

        [HttpPost]
        public int Add(Problems problems)
        {
            return _problemsService.Add(problems); 
        }

        [HttpPut("{id}")]
        public int Update(Problems problems)
        {
            return _problemsService.Update(problems);
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _problemsService.Delete(id);   
        }
    }
}
