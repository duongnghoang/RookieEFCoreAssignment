using Domain.Interfaces;

namespace Application.Dtos.ResponseDtos.Departments;

public class DepartmentResponseDto : IResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}