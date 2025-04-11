using Domain.Interfaces;

namespace Application.Dtos.ResponseDtos.Salaries;

public class SalaryResponseDto : IResponseDto
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public decimal SalaryAmount { get; set; }
}