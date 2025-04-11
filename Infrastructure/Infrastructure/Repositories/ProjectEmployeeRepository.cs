using Application.Dtos.ResponseDtos.ProjectEmployees;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Data;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories;

public class ProjectEmployeeRepository : BaseRepository<ProjectEmployee, ProjectEmployeeResponseDto>, IProjectEmployeeRepository
{
    public ProjectEmployeeRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<ProjectEmployee?> GetProjectEmployeeByIds(int employeeId, int projectId)
    {
        return await Context.ProjectEmployees.FindAsync(employeeId, projectId);
    }
}