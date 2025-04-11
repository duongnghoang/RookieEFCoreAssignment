using Domain.Interfaces;

namespace Application.Dtos.ResponseDtos.Projects;

public class ProjectResponseDto : IResponseDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
}