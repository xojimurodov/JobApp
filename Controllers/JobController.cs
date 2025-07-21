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
    public async Task<ActionResult<IEnumerable<Job>>> GetJobs()
    {
        try
        {
            if (_jobService == null)
            {
                return NotFound("Job service is not available.");
            }
            var jobs = Ok(await _jobService.GetAllAsync());
            return Ok(jobs);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Job>> GetJob(int id)
    {
        if (_jobService == null)
        {
            return NotFound("Job service is not available.");
        }
        try
        {
            var job = await _jobService.GetByIdAsync(id);
            return job is null ? NotFound() : Ok(job);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Job>> CreateJob(JobDto dto)
    {
        try
        {
            var created = await _jobService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetJob), new { id = created.Id }, created);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateJob(int id, JobDto dto)
    {
        try
        {
            var updated = await _jobService.UpdateAsync(id, dto);
            return updated ? NoContent() : NotFound();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteJob(int id)
    {
        try
        {
            var deleted = await _jobService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
