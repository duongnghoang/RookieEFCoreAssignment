using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

/// <summary>
/// Configuration class for the <see cref="Project"/> model.
/// </summary>
internal sealed class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        // Configure primary key
        builder.HasKey(project => project.Id);

        // Configure relationships
        builder.Property(project => project.Name)
            .HasMaxLength(100);
    }
}