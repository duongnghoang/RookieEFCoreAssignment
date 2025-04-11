using Domain.Interfaces;

namespace Application.Dtos.ResponseDtos.Employees;

public class EmployeeResponseDto : IResponseDto
{
    public int Id { get; set; }
    public string? Name { get; set; } = string.Empty;
    public int DepartmentId { get; set; }
    public DateOnly JoinedDate { get; set; }
    public decimal SalaryAmount { get; set; }
}