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
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var res = await _problemsService.GetAll();
                return Ok(new { isSuccess = true, data = res });
                //return await _problemsService.GetAll();
            }
            catch (Exception ex) {
                return new JsonResult(new {
                    isSuccess = false,
                    StatusCode = 500,
                    message = ex.Message
                
                });  
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try {
                var res = await _problemsService.GetById(id);
                return Ok(new { isSuccess = true, data = res });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    isSuccess = false,
                    StatusCode = 500,
                    message = ex.Message

                });
            }


        }

        [HttpPost]
        public async Task<IActionResult> Add(Problems problems)
        {
            try {
                var res = await _problemsService.Add(problems);
                return Ok(new { isSuccess = true, data = res });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    isSuccess = false,
                    StatusCode = 500,
                    message = ex.Message

                });
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Problems problems)
        {
            try
            {
                var res = await _problemsService.Update(problems);
                return Ok(new { isSuccess = true, data = res });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    isSuccess = false,
                    StatusCode = 500,
                    message = ex.Message

                });
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try {
                var res = await _problemsService.Delete(id);
                return Ok(new { isSuccess = true, data = res });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    isSuccess = false,
                    StatusCode = 500,
                    message = ex.Message

                });
            }

        }
    }
}
