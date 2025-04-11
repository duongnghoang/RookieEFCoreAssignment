using Application.Facades.Departments;
using Application.Facades.Employees;
using Application.Facades.ProjectEmployees;
using Application.Facades.Projects;
using Application.Facades.Salaries;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

/// <summary>
/// Dependency injection extension method for the registering Application layer.
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Add Application services
        services.AddScoped<IEmployeeFacade, EmployeeFacade>();
        services.AddScoped<IDepartmentFacade, DepartmentFacade>();
        services.AddScoped<IProjectFacade, ProjectFacade>();
        services.AddScoped<IProjectEmployeeFacade, ProjectEmployeeFacade>();
        services.AddScoped<ISalaryFacade, SalaryFacade>();

        return services;
    }
}