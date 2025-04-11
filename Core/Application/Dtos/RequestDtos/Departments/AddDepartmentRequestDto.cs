using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.RequestDtos.Departments;

public class AddDepartmentRequestDto
{
    [Required]
    public string? Name { get; set; }
}