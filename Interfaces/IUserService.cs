using JobApp.DTOs;
using JobApp.Models;

namespace JobApp.Interfaces;

public interface IUserService
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task<User> CreateAsync(UserDto dto);
    Task<bool> UpdateAsync(int id, UserDto dto);
    Task<bool> DeleteAsync(int id);
}
