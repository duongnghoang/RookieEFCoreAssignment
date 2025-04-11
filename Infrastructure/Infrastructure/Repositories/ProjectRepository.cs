using Application.Dtos.ResponseDtos.Projects;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Data;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories;

public class ProjectRepository : BaseRepository<Project, ProjectResponseDto>, IProjectRepository
{
    public ProjectRepository(ApplicationDbContext context) : base(context)
    {
    }
}