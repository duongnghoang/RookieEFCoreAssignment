using Application.Dtos.ResponseDtos.Projects;

namespace Application.Dtos.ResponseDtos.Employees;

public class EmployeeWithProjectResponseDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<ProjectResponseDto> Projects { get; set; } = [];
}