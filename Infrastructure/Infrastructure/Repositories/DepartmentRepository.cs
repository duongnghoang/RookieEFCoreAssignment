using Application.Dtos.ResponseDtos.Departments;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Data;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories;

public class DepartmentRepository : BaseRepository<Department, DepartmentResponseDto>, IDepartmentRepository
{
    public DepartmentRepository(ApplicationDbContext context) : base(context)
    {
    }
}