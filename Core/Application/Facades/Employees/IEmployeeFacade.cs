using Application.Dtos.RequestDtos.Employees;
using Application.Dtos.ResponseDtos.Employees;
using Domain.Shared;

namespace Application.Facades.Employees;

public interface IEmployeeFacade
{
    Task<Result<IEnumerable<EmployeeResponseDto>>> GetAllEmployees();
    Task<Result<EmployeeResponseDto>> GetEmployeeById(int id);
    Task<Result<IEnumerable<EmployeeWithNameResponseDto>>> GetEmployeesWithDepartmentName();
    Task<Result> AddEmployee(AddEmployeeRequestDto request);
    Task<Result> UpdateEmployee(int id, UpdateEmployeeRequestDto request);
    Task<Result> DeleteEmployee(int id);
    Task<Result> GetEmployeesWithConditions();
    Task<Result<IEnumerable<EmployeeWithProjectResponseDto>>> GetEmployeeWithProjects();
}