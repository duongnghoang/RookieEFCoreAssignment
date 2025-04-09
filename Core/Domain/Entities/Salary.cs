namespace Domain.Entities;

public class Salary
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public decimal SalaryAmount { get; set; }
    public Employee Employee { get; set; } = null!;
}