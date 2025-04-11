namespace Application.Dtos.RequestDtos.Employees;

public class UpdateEmployeeRequestDto
{
    public required string Name { get; set; }
    public DateOnly JoinedDate { get; set; }
    public int DepartmentId { get; set; }
}