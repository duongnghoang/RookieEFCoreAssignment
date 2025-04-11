using Application.Dtos.RequestDtos.Projects;
using Application.Dtos.ResponseDtos.Projects;
using Domain.Shared;

namespace Application.Facades.Projects;

public interface IProjectFacade
{
    Task<Result<IEnumerable<ProjectResponseDto>>> GetAllProjects();
    Task<Result<ProjectResponseDto>> GetProjectById(int id);
    Task<Result> AddProject(AddProjectRequestDto request);
    Task<Result> UpdateProject(int id, UpdateProjectRequestDto request);
    Task<Result> DeleteProject(int id);
}