using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.RequestDtos.Projects;

public class UpdateProjectRequestDto
{
    [Required]
    public string? Name { get; set; }
}