using Application.Dtos.RequestDtos.Departments;
using Application.Dtos.ResponseDtos.Departments;
using Domain.Shared;

namespace Application.Facades.Departments;

public interface IDepartmentFacade
{
    Task<Result<IEnumerable<DepartmentResponseDto>>> GetAllDepartments();
    Task<Result<DepartmentResponseDto>> GetDepartmentById(int id);
    Task<Result> AddDepartment(AddDepartmentRequestDto request);
    Task<Result> UpdateDepartment(int id, UpdateDepartmentRequestDto request);
    Task<Result> DeleteDepartment(int id);
}