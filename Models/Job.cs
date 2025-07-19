namespace JobApp.Models;

public class Job
{
    public int Id { get; set; }
    public required string Type { get; set; }
    public required string Company { get; set; }
    public Gender Gender { get; set; }
    public int Salary { get; set; }
    public DateOnly PunishedDate { get; set; }
    public bool Actual { get; set; }
}