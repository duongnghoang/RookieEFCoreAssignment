using Application.Dtos.RequestDtos.Employees;
using Application.Dtos.ResponseDtos.Employees;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Domain.Shared;
using Mapster;

namespace Application.Facades.Employees;

public class EmployeeFacade : IEmployeeFacade
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ISalaryRepository _salaryRepository;
    private readonly ITransactionManager _transactionManager;

    public EmployeeFacade(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository,
        ISalaryRepository salaryRepository, ITransactionManager transactionManager)
    {
        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
        _salaryRepository = salaryRepository;
        _transactionManager = transactionManager;
    }

    public async Task<Result<IEnumerable<EmployeeResponseDto>>> GetAllEmployees()
    {
        var employees = await _employeeRepository.GetAllAsync();

        return Result.Success(employees);
    }

    public async Task<Result<EmployeeResponseDto>> GetEmployeeById(int id)
    {
        var employee = await _employeeRepository.GetByIdWithSalaryAsync(id);
        if (employee == null) return Result.Failure<EmployeeResponseDto>($"Employee with id {id} not found");

        return Result.Success(employee);
    }

    public async Task<Result<IEnumerable<EmployeeWithNameResponseDto>>> GetEmployeesWithDepartmentName()
    {
        var employees = await _employeeRepository.GetWithDepartmentNameAsync();

        return Result.Success(employees);
    }

    public async Task<Result> AddEmployee(AddEmployeeRequestDto request)
    {
        // Begin a transaction
        await _transactionManager.BeginTransactionAsync();
        try
        {
            // Check if the department exists
            var department = await _departmentRepository.GetByIdAsync(request.DepartmentId);
            if (department == null) return Result.Failure("Department not found");

            var employee = request.Adapt<Employee>();

            // Add the employee to the database
            await _employeeRepository.AddAsync(employee);
            await _employeeRepository.SaveChangesAsync();

            // Add the salary of the employee
            var salary = new Salary
            {
                EmployeeId = employee.Id,
                SalaryAmount = request.SalaryAmount
            };
            await _salaryRepository.AddAsync(salary);
            await _salaryRepository.SaveChangesAsync();

            await _transactionManager.CommitTransactionAsync();

            return Result.Success();
        }
        catch (Exception ex)
        {
            await _transactionManager.RollbackTransactionAsync();
            throw new Exception($"An error occurred during transaction adding the employee: {ex.Message}", ex);
        }
    }

    public async Task<Result> UpdateEmployee(int id, UpdateEmployeeRequestDto request)
    {
        // Check if the employee exists
        var employee = await _employeeRepository.GetByIdAsync(id);
        if (employee == null) return Result.Failure($"Employee with id {id} not found");

        // Check if the update department exists
        var department = await _departmentRepository.GetByIdAsync(request.DepartmentId);
        if (department == null) return Result.Failure("Department not found");

        // Update the employee
        employee.Name = request.Name;
        employee.JoinedDate = request.JoinedDate;
        employee.DepartmentId = request.DepartmentId;
        _employeeRepository.Update(employee);
        await _employeeRepository.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result> DeleteEmployee(int id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);
        if (employee == null) return Result.Failure($"Employee with id {id} not found");
        _employeeRepository.Delete(employee);
        await _employeeRepository.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result> GetEmployeesWithConditions()
    {
        var employees = await _employeeRepository.GetEmployeesGreaterSalaryAndJoinedDate();

        return Result.Success(employees);
    }

    public async Task<Result<IEnumerable<EmployeeWithProjectResponseDto>>> GetEmployeeWithProjects()
    {
        var employees = await _employeeRepository.GetEmployeesWithProjects();

        return Result.Success(employees);
    }
}