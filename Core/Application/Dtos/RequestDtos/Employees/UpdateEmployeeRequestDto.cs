using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.RequestDtos.Employees;

public class UpdateEmployeeRequestDto
{
    [Required]
    public string? Name { get; set; }
    public DateOnly JoinedDate { get; set; }
    public int DepartmentId { get; set; }
}