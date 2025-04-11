using Application.Dtos.ResponseDtos.Salaries;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Data;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories;

public class SalaryRepository : BaseRepository<Salary, SalaryResponseDto>, ISalaryRepository
{
    public SalaryRepository(ApplicationDbContext context) : base(context)
    {
    }
}