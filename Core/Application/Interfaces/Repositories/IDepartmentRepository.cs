using Application.Dtos.ResponseDtos.Departments;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Interfaces.Repositories;

public interface IDepartmentRepository : IBaseRepository<Department, DepartmentResponseDto>
{
    
}