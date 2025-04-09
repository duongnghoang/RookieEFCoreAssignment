using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

/// <summary>
/// Configuration class for the <see cref="ProjectEmployee"/> model.
/// </summary>
internal sealed class ProjectEmployeeConfiguration : IEntityTypeConfiguration<ProjectEmployee>
{
    public void Configure(EntityTypeBuilder<ProjectEmployee> builder)
    {
        // Configure primary key
        builder.HasKey(projectEmployee => new { projectEmployee.EmployeeId, projectEmployee.ProjectId });

        // Configure relationships
        // Many-to-one relationship with Project
        builder.HasOne(projectEmployee => projectEmployee.Project)
            .WithMany(project => project.ProjectEmployees)
            .HasForeignKey(projectEmployee => projectEmployee.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        // Many-to-one relationship with Employee
        builder.HasOne(projectEmployee => projectEmployee.Employee)
            .WithMany(employee => employee.ProjectEmployees)
            .HasForeignKey(projectEmployee => projectEmployee.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}