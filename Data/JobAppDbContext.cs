using JobApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApp.Data;

public class JobAppDbContext(DbContextOptions<JobAppDbContext> options) : DbContext(options)
{
    public DbSet<Job> Jobs { get; set; }
    public DbSet<User> Users { get; set; }

}
