using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class ProjectEmployeeConfiguration : IEntityTypeConfiguration<ProjectEmployee>
{
    public void Configure(EntityTypeBuilder<ProjectEmployee> builder)
    {
        builder.HasKey(projectEmployee => new { projectEmployee.EmployeeId, projectEmployee.ProjectId });

        builder.HasOne(projectEmployee => projectEmployee.Project)
            .WithMany(project => project.ProjectEmployees)
            .HasForeignKey(projectEmployee => projectEmployee.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(projectEmployee => projectEmployee.Employee)
            .WithMany(employee => employee.ProjectEmployees)
            .HasForeignKey(projectEmployee => projectEmployee.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}