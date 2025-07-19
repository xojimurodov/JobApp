using JobApp.Models;

namespace JobApp.DTOs;

public class JobDto
{
    public string Type { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public int Salary { get; set; }
    public DateOnly PunishedDate { get; set; }
    public bool Actual { get; set; }
}
