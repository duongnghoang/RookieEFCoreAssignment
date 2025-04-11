using Application.Dtos.ResponseDtos.Employees;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Interfaces.Repositories;

public interface IEmployeeRepository : IBaseRepository<Employee, EmployeeResponseDto>
{
    Task<IEnumerable<EmployeeWithNameResponseDto>> GetWithDepartmentNameAsync();
    Task<EmployeeResponseDto?> GetByIdWithSalaryAsync(int id);
    Task<IEnumerable<EmployeeResponseDto>> GetEmployeesGreaterSalaryAndJoinedDate();
}