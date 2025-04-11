using Application.Dtos.RequestDtos.Projects;
using Application.Facades.Projects;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectFacade _projectFacade;

        public ProjectsController(IProjectFacade projectFacade)
        {
            _projectFacade = projectFacade;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var result = await _projectFacade.GetAllProjects();

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProjectById(int id)
        {
            var result = await _projectFacade.GetProjectById(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddProject([FromBody] AddProjectRequestDto request)
        {
            var result = await _projectFacade.AddProject(request);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Created("", result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] UpdateProjectRequestDto request)
        {
            var result = await _projectFacade.UpdateProject(id, request);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var result = await _projectFacade.DeleteProject(id);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}