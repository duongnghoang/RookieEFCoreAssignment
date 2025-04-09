using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

internal sealed class SalaryConfiguration : IEntityTypeConfiguration<Salary>
{
    public void Configure(EntityTypeBuilder<Salary> builder)
    {
        builder.HasKey(salary => salary.Id);

        builder.HasOne(salary => salary.Employee)
            .WithOne(employee => employee.Salary)
            .HasForeignKey<Salary>(salary => salary.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(salary => salary.SalaryAmount)
            .HasColumnType("decimal")
            .HasPrecision(18, 2);
    }
}