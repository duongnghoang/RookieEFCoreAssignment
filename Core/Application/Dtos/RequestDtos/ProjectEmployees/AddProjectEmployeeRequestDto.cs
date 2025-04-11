namespace Application.Dtos.RequestDtos.ProjectEmployees;

public class AddProjectEmployeeRequestDto
{
    public int EmployeeId { get; set; }
    public int ProjectId { get; set; }
    public bool Enable { get; set; }
}