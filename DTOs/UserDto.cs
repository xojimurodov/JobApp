using JobApp.Models;

namespace JobApp.DTOs;

public class UserDto
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public Gender Gender { get; set; }
}
