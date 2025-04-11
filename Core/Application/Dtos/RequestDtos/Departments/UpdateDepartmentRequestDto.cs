using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.RequestDtos.Departments;

public class UpdateDepartmentRequestDto
{
    [Required]
    public string? Name { get; set; }
}