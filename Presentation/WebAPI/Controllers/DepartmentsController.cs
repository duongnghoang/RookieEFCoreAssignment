using Application.Dtos.RequestDtos.Departments;
using Application.Facades.Departments;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentFacade _departmentFacade;

        public DepartmentsController(IDepartmentFacade departmentFacade)
        {
            _departmentFacade = departmentFacade;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var result = await _departmentFacade.GetAllDepartments();

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var result = await _departmentFacade.GetDepartmentById(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment([FromBody] AddDepartmentRequestDto request)
        {
            var result = await _departmentFacade.AddDepartment(request);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Created("", result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] UpdateDepartmentRequestDto request)
        {
            var result = await _departmentFacade.UpdateDepartment(id, request);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var result = await _departmentFacade.DeleteDepartment(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}