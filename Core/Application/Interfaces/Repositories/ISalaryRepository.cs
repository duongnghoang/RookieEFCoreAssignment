using Application.Dtos.ResponseDtos.Salaries;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Interfaces.Repositories;

public interface ISalaryRepository : IBaseRepository<Salary, SalaryResponseDto>
{
}