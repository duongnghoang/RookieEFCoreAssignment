using Application.Dtos.RequestDtos.ProjectEmployees;
using Application.Dtos.ResponseDtos.ProjectEmployees;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Domain.Shared;
using Mapster;

namespace Application.Facades.ProjectEmployees;

public class ProjectEmployeeFacade : IProjectEmployeeFacade
{
    private readonly IProjectEmployeeRepository _projectEmployeeRepository;

    public ProjectEmployeeFacade(IProjectEmployeeRepository projectEmployeeRepository)
    {
        _projectEmployeeRepository = projectEmployeeRepository;
    }

    public async Task<Result<IEnumerable<ProjectEmployeeResponseDto>>> GetAllProjectEmployees()
    {
        var projectEmployees = await _projectEmployeeRepository.GetAllAsync();
        return Result.Success(projectEmployees);
    }

    public async Task<Result<ProjectEmployeeResponseDto>> GetProjectEmployeeById(int employeeId, int projectId)
    {
        var projectEmployee = await _projectEmployeeRepository.GetProjectEmployeeByIds(employeeId, projectId);
        if (projectEmployee == null) return Result.Failure<ProjectEmployeeResponseDto>($"ProjectEmployee with employee id {employeeId} and project id {projectId} not found");

        return Result.Success(projectEmployee.Adapt<ProjectEmployeeResponseDto>());
    }

    public async Task<Result> AddProjectEmployee(AddProjectEmployeeRequestDto request)
    {
        // Check if the project employee already exists
        var existingProjectEmployee = await _projectEmployeeRepository.GetProjectEmployeeByIds(request.EmployeeId, request.ProjectId);
        if (existingProjectEmployee != null)
        {
            return Result.Failure($"ProjectEmployee with employee id {request.EmployeeId} and project id {request.ProjectId} already exists");
        }

        // Add the project employee
        var projectEmployee = request.Adapt<ProjectEmployee>();
        await _projectEmployeeRepository.AddAsync(projectEmployee);
        await _projectEmployeeRepository.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result> UpdateProjectEmployee(int employeeId, int projectId, UpdateProjectEmployeeRequestDto request)
    {
        // Check if the project employee exists
        var projectEmployee = await _projectEmployeeRepository.GetProjectEmployeeByIds(employeeId, projectId);
        if (projectEmployee == null) return Result.Failure($"ProjectEmployee with employee id {employeeId} and project id {projectId} not found");

        // Update the project employee properties
        projectEmployee.Enable = request.Enable;

        // Update the project employee
        _projectEmployeeRepository.Update(projectEmployee);
        await _projectEmployeeRepository.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result> DeleteProjectEmployee(int employeeId, int projectId)
    {
        // Check if the project employee exists
        var projectEmployee = await _projectEmployeeRepository.GetProjectEmployeeByIds(employeeId, projectId);
        if (projectEmployee == null) return Result.Failure($"ProjectEmployee with employee id {employeeId} and project id {projectId} not found");

        // Delete the project employee
        _projectEmployeeRepository.Delete(projectEmployee);
        await _projectEmployeeRepository.SaveChangesAsync();

        return Result.Success();
    }
}