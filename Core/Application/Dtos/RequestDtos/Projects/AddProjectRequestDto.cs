using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.RequestDtos.Projects;

public class AddProjectRequestDto
{
    [Required]
    public string? Name { get; set; }
}