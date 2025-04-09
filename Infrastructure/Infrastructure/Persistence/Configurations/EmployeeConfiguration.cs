using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

/// <summary>
/// Configuration class for the <see cref="Employee"/> model.
/// </summary>
internal sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        // Configure primary key
        builder.HasKey(employee => employee.Id);

        // Configure relationships
        // Many-to-one relationship with Department
        builder.HasOne(employee => employee.Department)
            .WithMany(department => department.Employees)
            .HasForeignKey(employee => employee.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure properties
        builder.Property(department => department.Name)
            .HasMaxLength(50);

        // Seed data
        builder.HasData(
            new Employee { Id = 1, Name = "John Doe", DepartmentId = 1, JoinedDate = new DateTime(2020, 5, 1) },
            new Employee { Id = 2, Name = "Jane Smith", DepartmentId = 2, JoinedDate = new DateTime(2021, 3, 15) }
        );
    }
}