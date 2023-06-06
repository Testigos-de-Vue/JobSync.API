using System.Net.Mime;
using AutoMapper;
using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Domain.Services.Communication;
using JobSync.API.Recruitment.Resources;
using JobSync.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace JobSync.API.Recruitment.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class JobAreasController: ControllerBase
{
    private readonly IJobAreaService _jobAreaService;
    private readonly IMapper _mapper;
    
    public JobAreasController(IJobAreaService jobAreaService, IMapper mapper)
    {
        _jobAreaService = jobAreaService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<JobAreaResource>), 200)]
    public async Task<IEnumerable<JobAreaResource>> GetAllAsync()
    {
        var jobAreas = await _jobAreaService.ListAsync();
        var resources = _mapper.Map<IEnumerable<JobArea>, IEnumerable<JobAreaResource>>(jobAreas);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveJobAreaResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var jobArea = _mapper.Map<SaveJobAreaResource, JobArea>(resource);
        var result = await _jobAreaService.SaveAsync(jobArea);

        if (!result.Success)
            return BadRequest(result.Message);

        var jobAreaResource = _mapper.Map<JobArea, JobAreaResource>(result.Resource);
        return Created(nameof(PostAsync), jobAreaResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveJobAreaResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var jobArea = _mapper.Map<SaveJobAreaResource, JobArea>(resource);
        var result = await _jobAreaService.UpdateAsync(id, jobArea);

        if (!result.Success)
            return BadRequest(result.Message);

        var jobAreaResource = _mapper.Map<JobArea, JobAreaResource>(result.Resource);
        return Ok(jobAreaResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _jobAreaService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var jobAreaResource = _mapper.Map<JobArea, JobAreaResource>(result.Resource);
        return Ok(jobAreaResource);
    }
}