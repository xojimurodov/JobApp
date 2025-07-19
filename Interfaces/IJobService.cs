using JobApp.Models;
using JobApp.DTOs;

namespace JobApp.Interfaces;

public interface IJobService
{
    Task<IEnumerable<Job>> GetAllAsync();
    Task<Job?> GetByIdAsync(int id);
    Task<Job> CreateAsync(JobDto dto);
    Task<bool> UpdateAsync(int id, JobDto dto);
    Task<bool> DeleteAsync(int id);
}
