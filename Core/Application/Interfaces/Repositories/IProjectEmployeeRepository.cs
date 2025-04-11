using Application.Dtos.ResponseDtos.ProjectEmployees;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Interfaces.Repositories;

public interface IProjectEmployeeRepository : IBaseRepository<ProjectEmployee, ProjectEmployeeResponseDto>
{
    Task<ProjectEmployee?> GetProjectEmployeeByIds(int employeeId, int projectId);
}