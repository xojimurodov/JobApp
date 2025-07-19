using JobApp.Models;
using JobApp.DTOs;
using JobApp.Interfaces;
using JobApp.Data;
using Microsoft.EntityFrameworkCore;

namespace JobApp.Services;

public class JobService(JobAppDbContext context) : IJobService
{
    private readonly JobAppDbContext _context = context;

    public async Task<IEnumerable<Job>> GetAllAsync() => await _context.Jobs.ToListAsync();

    public async Task<Job?> GetByIdAsync(int id) => await _context.Jobs.FindAsync(id);

    public async Task<Job> CreateAsync(JobDto dto)
    {
        var job = new Job
        {
            Type = dto.Type,
            Company = dto.Company,
            Gender = dto.Gender,
            Salary = dto.Salary,
            PunishedDate = dto.PunishedDate,
            Actual = dto.Actual
        };

        _context.Jobs.Add(job);
        await _context.SaveChangesAsync();
        return job;
    }

    public async Task<bool> UpdateAsync(int id, JobDto dto)
    {
        var job = await _context.Jobs.FindAsync(id);
        if (job == null) return false;

        job.Type = dto.Type;
        job.Company = dto.Company;
        job.Gender = dto.Gender;
        job.Salary = dto.Salary;
        job.PunishedDate = dto.PunishedDate;
        job.Actual = dto.Actual;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var job = await _context.Jobs.FindAsync(id);
        if (job == null) return false;

        _context.Jobs.Remove(job);
        await _context.SaveChangesAsync();
        return true;
    }
}
