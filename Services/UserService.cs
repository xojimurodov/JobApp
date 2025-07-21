using JobApp.Data;
using JobApp.DTOs;
using JobApp.Interfaces;
using JobApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApp.Services;

public class UserService(JobAppDbContext context) : IUserService
{
    public async Task<List<User>> GetAllAsync() => await context.Users.ToListAsync();

    public async Task<User?> GetByIdAsync(int id) => await context.Users.FindAsync(id);

    public async Task<User> CreateAsync(UserDto dto)
    {
        var user = new User
        {
            Username = dto.Username,
            Email = dto.Email,
            Password = dto.Password,
            Gender = dto.Gender
        };
        context.Users.Add(user);
        await context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> UpdateAsync(int id, UserDto dto)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null) return false;

        user.Username = dto.Username;
        user.Email = dto.Email;
        user.Password = dto.Password;
        user.Gender = dto.Gender;
        await context.SaveChangesAsync();
        return true;
    }


    public async Task<bool> DeleteAsync(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null) return false;

        context.Users.Remove(user);
        await context.SaveChangesAsync();
        return true;
    }
}
