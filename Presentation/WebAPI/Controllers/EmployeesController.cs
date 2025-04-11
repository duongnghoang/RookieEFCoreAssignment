using Application.Dtos.RequestDtos.Employees;
using Application.Facades.Employees;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeFacade _employeeFacade;

        public EmployeesController(IEmployeeFacade employeeFacade)
        {
            _employeeFacade = employeeFacade;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeFacade.GetAllEmployees();

            return Ok(employees);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdEmployees(int id)
        {
            var result = await _employeeFacade.GetEmployeeById(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeRequestDto request)
        {
            var result = await _employeeFacade.AddEmployee(request);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Created("", result);
        }

        [HttpGet("get-department-name")]
        public async Task<IActionResult> GetEmployeeDepartmentName()
        {
            var employeesWithDepartmentName = await _employeeFacade.GetEmployeesWithDepartmentName();

            return Ok(employeesWithDepartmentName);
        }

        [HttpGet("get-with-salary-greater-and-joined-date")]
        public async Task<IActionResult> GetWithSalaryGreaterAndJoinedDate()
        {
            var employees = await _employeeFacade.GetEmployeesWithConditions();

            return Ok(employees);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] UpdateEmployeeRequestDto request)
        {
            var result = await _employeeFacade.UpdateEmployee(id, request);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employeeFacade.DeleteEmployee(id);
            if (!result.IsSuccess)
            {
                BadRequest(result);
            }

            return NoContent();
        }
    }
}
