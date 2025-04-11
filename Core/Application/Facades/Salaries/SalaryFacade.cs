using Application.Dtos.RequestDtos.Salaries;
using Application.Dtos.ResponseDtos.Salaries;
using Application.Interfaces.Repositories;
using Domain.Shared;
using Mapster;

namespace Application.Facades.Salaries;

public class SalaryFacade : ISalaryFacade
{
    private readonly ISalaryRepository _salaryService;

    public SalaryFacade(ISalaryRepository salaryService)
    {
        _salaryService = salaryService;
    }

    public async Task<Result<IEnumerable<SalaryResponseDto>>> GetAllSalaries()
    {
        var salaries = await _salaryService.GetAllAsync();

        return Result.Success(salaries);
    }

    public async Task<Result<SalaryResponseDto>> GetSalaryById(int id)
    {
        var salary = await _salaryService.GetByIdAsync(id);
        if (salary == null) return Result.Failure<SalaryResponseDto>($"Salary with id {id} not found");

        return Result.Success(salary.Adapt<SalaryResponseDto>());
    }   

    public async Task<Result> UpdateSalary(int id, UpdateSalaryRequestDto request)
    {
        // Check if the salary exists
        var salary = await _salaryService.GetByIdAsync(id);
        if (salary == null) return Result.Failure($"Salary with id {id} not found");

        // Update the salary properties
        salary.SalaryAmount = request.SalaryAmount;
        _salaryService.Update(salary);
        await _salaryService.SaveChangesAsync();

        return Result.Success();
    }
}