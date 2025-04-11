using Application.Dtos.RequestDtos.Salaries;
using Application.Facades.Salaries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalariesController : ControllerBase
    {
        private readonly ISalaryFacade _salaryFacade;

        public SalariesController(ISalaryFacade salaryFacade)
        {
            _salaryFacade = salaryFacade;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSalaries()
        {
            var result = await _salaryFacade.GetAllSalaries();

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSalaryById(int id)
        {
            var result = await _salaryFacade.GetSalaryById(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateSalary(int id, [FromBody] UpdateSalaryRequestDto request)
        {
            var result = await _salaryFacade.UpdateSalary(id, request);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
