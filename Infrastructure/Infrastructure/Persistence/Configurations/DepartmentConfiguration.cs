﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

/// <summary>
/// Configuration class for the <see cref="Department"/> model.
/// </summary>
internal sealed class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        // Configure primary key
        builder.HasKey(department => department.Id);

        // Configure properties
        builder.Property(department => department.Name)
            .HasMaxLength(50);

        // Seed data
        builder.HasData(
            new Department { Id = 1, Name = "Software Development" },
            new Department { Id = 2, Name = "Finance" },
            new Department { Id = 3, Name = "Accountant" },
            new Department { Id = 4, Name = "HR" }
            );
    }
}