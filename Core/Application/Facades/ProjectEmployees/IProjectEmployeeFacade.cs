using Application.Dtos.RequestDtos.ProjectEmployees;
using Application.Dtos.ResponseDtos.ProjectEmployees;
using Domain.Shared;

namespace Application.Facades.ProjectEmployees;

public interface IProjectEmployeeFacade
{
    Task<Result<IEnumerable<ProjectEmployeeResponseDto>>> GetAllProjectEmployees();
    Task<Result<ProjectEmployeeResponseDto>> GetProjectEmployeeById(int employeeId, int projectId);
    Task<Result> AddProjectEmployee(AddProjectEmployeeRequestDto request);
    Task<Result> UpdateProjectEmployee(int employeeId, int projectId, UpdateProjectEmployeeRequestDto request);
    Task<Result> DeleteProjectEmployee(int employeeId, int projectId);
}