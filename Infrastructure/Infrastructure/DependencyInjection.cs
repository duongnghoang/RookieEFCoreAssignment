using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Interfaces;
using Infrastructure.Persistence.Data;
using Infrastructure.Persistence.Transactions;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

/// <summary>
/// Dependency injection extension method for the registering Infrastructure layer.
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Add Persistence
        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

        // Add Repositories
        services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));

        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<ISalaryRepository, SalaryRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IProjectEmployeeRepository, ProjectEmployeeRepository>();

        services.AddScoped<ITransactionManager, TransactionManager>();

        return services;
    }
}