using Application.Dtos.ResponseDtos.Projects;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Interfaces.Repositories;

public interface IProjectRepository : IBaseRepository<Project, ProjectResponseDto>
{
}