namespace Application.Dtos.ResponseDtos.Employees;

public class EmployeeWithNameResponseDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? DepartmentName { get; set; }
    public DateOnly JoinedDate { get; set; }
}