using Application.Dtos.RequestDtos.Salaries;
using Application.Dtos.ResponseDtos.Salaries;
using Domain.Shared;

namespace Application.Facades.Salaries;

public interface ISalaryFacade
{
    Task<Result<IEnumerable<SalaryResponseDto>>> GetAllSalaries();
    Task<Result<SalaryResponseDto>> GetSalaryById(int id);
    Task<Result> UpdateSalary(int id, UpdateSalaryRequestDto request);
}