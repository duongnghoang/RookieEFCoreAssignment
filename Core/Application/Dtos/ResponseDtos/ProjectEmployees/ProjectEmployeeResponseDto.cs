using Domain.Interfaces;

namespace Application.Dtos.ResponseDtos.ProjectEmployees;

public class ProjectEmployeeResponseDto : IResponseDto
{
    public int EmployeeId { get; set; }
    public int ProjectId { get; set; }
    public bool Enable { get; set; }
}