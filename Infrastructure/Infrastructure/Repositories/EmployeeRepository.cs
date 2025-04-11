using Application.Dtos.ResponseDtos.Employees;
using Application.Dtos.ResponseDtos.Projects;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Data;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Infrastructure.Repositories;

public class EmployeeRepository : BaseRepository<Employee, EmployeeResponseDto>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationDbContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<EmployeeResponseDto>> GetAllAsync()
    {
        var employees = Context.Employees
            .Include(e => e.Salary)
            .AsNoTracking()
            .Select(e => new EmployeeResponseDto
            {
                Id = e.Id,
                Name = e.Name,
                JoinedDate = e.JoinedDate,
                DepartmentId = e.DepartmentId,
                SalaryAmount = e.Salary.SalaryAmount
            });

        return await employees.ToListAsync();
    }

    public async Task<EmployeeResponseDto?> GetByIdWithSalaryAsync(int id)
    {
        var employee = await Context.Employees
            .Include(e => e.Salary)
            .AsNoTracking()
            .Select(e => new EmployeeResponseDto
            {
                Id = e.Id,
                Name = e.Name,
                JoinedDate = e.JoinedDate,
                DepartmentId = e.DepartmentId,
                SalaryAmount = e.Salary.SalaryAmount
            })
            .FirstOrDefaultAsync(e => e.Id == id);

        return employee;
    }

    public async Task<IEnumerable<EmployeeWithNameResponseDto>> GetWithDepartmentNameAsync()
    {
        // Using raw SQL query to get employees with department name
        // SQL Query suppports mapping to non-entity classes
        // EmployeeWithNameResponseDto has the same properties as the selected columns

        var employees = await Context.Database
            .SqlQueryRaw<EmployeeWithNameResponseDto>("""
                                                      SELECT 
                                                          [e].[Id],
                                                          [e].[Name],
                                                          [e].[JoinedDate],
                                                          [d].[Name] AS [DepartmentName] 
                                                      FROM 
                                                          [dbo].[Employees] [e]
                                                      INNER JOIN 
                                                          [dbo].[Departments] [d] 
                                                      ON
                                                          [e].[DepartmentId] = [d].[Id]
                                                      """)
            .AsNoTracking()
            .ToListAsync();

        return employees;
    }

    public async Task<IEnumerable<EmployeeResponseDto>> GetEmployeesGreaterSalaryAndJoinedDate()
    {
        var employees = await Context.Database
            .SqlQuery<EmployeeResponseDto>($"""
                                            SELECT 
                                                [e].[Id],
                                                [e].[Name],
                                                [e].[DepartmentId],
                                                [e].[JoinedDate],
                                                [s].[SalaryAmount]
                                            FROM 
                                                [dbo].[Employees] [e]
                                            INNER JOIN 
                                                [dbo].[Salaries] [s] 
                                            ON
                                                [e].[Id] = [s].[EmployeeId]
                                            WHERE 
                                                [s].[SalaryAmount] > 100
                                            AND
                                                  [e].[JoinedDate] >= '2024-01-01'
                                            """)
            .AsNoTracking()
            .ToListAsync();

        return employees;
    }

    public async Task<IEnumerable<EmployeeWithProjectResponseDto>> GetEmployeesWithProjects()
    {
        var employees = await Context.Employees
            .Include(e => e.ProjectEmployees) // Include the junction table
            .ThenInclude(ep => ep.Project) // Include related Projects
            .Select(e => new EmployeeWithProjectResponseDto
            {
                Id = e.Id,
                Name = e.Name,
                JoinedDate = e.JoinedDate,
                Projects = e.ProjectEmployees
                    .Select(ep => new ProjectResponseDto()
                    {
                        Id = ep.Project.Id,
                        Name = ep.Project.Name,
                    })
                    .ToList()
            })
            .ToListAsync();

        return employees;
    }
}