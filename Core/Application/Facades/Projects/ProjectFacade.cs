using Application.Dtos.RequestDtos.Projects;
using Application.Dtos.ResponseDtos.Projects;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Domain.Shared;
using Mapster;

namespace Application.Facades.Projects;

public class ProjectFacade : IProjectFacade
{
    private readonly IProjectRepository _projectRepository;

    public ProjectFacade(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Result<IEnumerable<ProjectResponseDto>>> GetAllProjects()
    {
        var projects = await _projectRepository.GetAllAsync();

        return Result.Success(projects);
    }

    public async Task<Result<ProjectResponseDto>> GetProjectById(int id)
    {
        var project = await _projectRepository.GetByIdAsync(id);
        if (project == null) return Result.Failure<ProjectResponseDto>($"Project with id {id} not found");

        return Result.Success(project.Adapt<ProjectResponseDto>());
    }

    public async Task<Result> AddProject(AddProjectRequestDto request)
    {
        var project = request.Adapt<Project>();

        await _projectRepository.AddAsync(project);
        await _projectRepository.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result> UpdateProject(int id, UpdateProjectRequestDto request)
    {
        // Check if the project exists
        var project = await _projectRepository.GetByIdAsync(id);
        if (project == null) return Result.Failure($"Project with id {id} not found");

        // Update the project properties
        project.Name = request.Name;
        _projectRepository.Update(project);
        await _projectRepository.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result> DeleteProject(int id)
    {
        // Check if the project exists
        var project = await _projectRepository.GetByIdAsync(id);
        if (project == null) return Result.Failure($"Project with id {id} not found");

        // Delete the project
        _projectRepository.Delete(project);
        await _projectRepository.SaveChangesAsync();

        return Result.Success();
    }
}