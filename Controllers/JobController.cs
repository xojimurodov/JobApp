using JobApp.DTOs;
using JobApp.Interfaces;
using JobApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobsController(IJobService jobService) : ControllerBase
{
    private readonly IJobService _jobService = jobService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Job>>> GetJobs() =>
        Ok(await _jobService.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Job>> GetJob(int id)
    {
        var job = await _jobService.GetByIdAsync(id);
        return job is null ? NotFound() : Ok(job);
    }

    [HttpPost]
    public async Task<ActionResult<Job>> CreateJob(JobDto dto)
    {
        var created = await _jobService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetJob), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateJob(int id, JobDto dto)
    {
        var updated = await _jobService.UpdateAsync(id, dto);
        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteJob(int id)
    {
        var deleted = await _jobService.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
