using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.RequestDtos.Employees;

public class AddEmployeeRequestDto
{
    [Required]
    public string? Name { get; set; }
    public int DepartmentId { get; set; }
    public DateOnly JoinedDate { get; set; }
    public decimal SalaryAmount { get; set; }
}