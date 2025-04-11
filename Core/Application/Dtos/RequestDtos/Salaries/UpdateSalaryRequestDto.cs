using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.RequestDtos.Salaries;

public class UpdateSalaryRequestDto
{
    [Required]
    public decimal SalaryAmount { get; set; }
}