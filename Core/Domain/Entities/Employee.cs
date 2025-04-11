namespace Domain.Entities;

public class Employee
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int DepartmentId { get; set; }
    public DateOnly JoinedDate { get; set; }
    public Department Department { get; set; } = null!;
    public Salary Salary { get; set; } = null!;
    public ICollection<ProjectEmployee> ProjectEmployees { get; set; } = null!;
}