using Application.Dtos.RequestDtos.ProjectEmployees;
using Application.Facades.ProjectEmployees;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectEmployeesController : ControllerBase
    {
        private readonly IProjectEmployeeFacade _projectEmployeeFacade;

        public ProjectEmployeesController(IProjectEmployeeFacade projectEmployeeFacade)
        {
            _projectEmployeeFacade = projectEmployeeFacade;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjectEmployees()
        {
            var result = await _projectEmployeeFacade.GetAllProjectEmployees();

            return Ok(result);
        }

        [HttpGet("{employeeId:int}/{projectId:int}")]
        public async Task<IActionResult> GetProjectEmployeeById(int employeeId, int projectId)
        {
            var result = await _projectEmployeeFacade.GetProjectEmployeeById(employeeId, projectId);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddProjectEmployee([FromBody] AddProjectEmployeeRequestDto request)
        {
            var result = await _projectEmployeeFacade.AddProjectEmployee(request);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Created("", result);
        }

        [HttpPut("{employeeId:int}/{projectId:int}")]
        public async Task<IActionResult> UpdateProjectEmployee(int employeeId, int projectId, [FromBody] UpdateProjectEmployeeRequestDto request)
        {
            var result = await _projectEmployeeFacade.UpdateProjectEmployee(employeeId, projectId, request);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("{employeeId:int}/{projectId:int}")]
        public async Task<IActionResult> DeleteProjectEmployee(int employeeId, int projectId)
        {
            var result = await _projectEmployeeFacade.DeleteProjectEmployee(employeeId, projectId);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}