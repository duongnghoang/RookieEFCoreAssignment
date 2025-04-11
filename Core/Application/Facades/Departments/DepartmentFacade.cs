using Application.Dtos.RequestDtos.Departments;
using Application.Dtos.ResponseDtos.Departments;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Domain.Shared;
using Mapster;

namespace Application.Facades.Departments;

public class DepartmentFacade : IDepartmentFacade
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentFacade(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<Result<IEnumerable<DepartmentResponseDto>>> GetAllDepartments()
    {
        var departments = await _departmentRepository.GetAllAsync();

        return Result.Success(departments);
    }

    public async Task<Result<DepartmentResponseDto>> GetDepartmentById(int id)
    {
        var department = await _departmentRepository.GetByIdAsync(id);
        if (department == null) return Result.Failure<DepartmentResponseDto>($"Department with id {id} not found");

        return Result.Success(department.Adapt<DepartmentResponseDto>());
    }

    public async Task<Result> AddDepartment(AddDepartmentRequestDto request)
    {
        var department = request.Adapt<Department>();

        await _departmentRepository.AddAsync(department);
        await _departmentRepository.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result> UpdateDepartment(int id, UpdateDepartmentRequestDto request)
    {
        // Check if the department exists
        var department = await _departmentRepository.GetByIdAsync(id);
        if (department == null) return Result.Failure($"Department with id {id} not found");

        // Update the department properties
        department.Name = request.Name;
        _departmentRepository.Update(department);
        await _departmentRepository.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result> DeleteDepartment(int id)
    {
        // Check if the department exists
        var department = await _departmentRepository.GetByIdAsync(id);
        if (department == null) return Result.Failure($"Department with id {id} not found");

        // Delete the department
        _departmentRepository.Delete(department);
        await _departmentRepository.SaveChangesAsync();

        return Result.Success();
    }
}