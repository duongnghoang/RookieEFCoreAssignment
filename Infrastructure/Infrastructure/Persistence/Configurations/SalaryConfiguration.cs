using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;


/// <summary>
/// Configuration class for the <see cref="Salary"/> model.
/// </summary>
internal sealed class SalaryConfiguration : IEntityTypeConfiguration<Salary>
{
    public void Configure(EntityTypeBuilder<Salary> builder)
    {
        // Configure primary key
        builder.HasKey(salary => salary.Id);

        // Configure relationships
        // One-to-one relationship with Employee
        builder.HasOne(salary => salary.Employee)
            .WithOne(employee => employee.Salary)
            .HasForeignKey<Salary>(salary => salary.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configure properties
        builder.Property(salary => salary.SalaryAmount)
            .HasColumnType("decimal")
            .HasPrecision(18, 2);

        // Seed data
        builder.HasData(
            new Salary { Id = 1, EmployeeId = 1, SalaryAmount = 50000 },
            new Salary { Id = 2, EmployeeId = 2, SalaryAmount = 60000 }
        );
    }
}