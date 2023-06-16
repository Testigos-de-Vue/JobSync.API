using System.Net.Mime;
using AutoMapper;
using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Domain.Services;
using JobSync.API.Recruitment.Resources;
using JobSync.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JobSync.API.Recruitment.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/recruitment/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete Recruitment Processes")]
public class ProcessesController: ControllerBase
{
    private readonly IProcessService _processService;
    private readonly IMapper _mapper;
    
    public ProcessesController(IProcessService processService, IMapper mapper)
    {
        _processService = processService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProcessResource>), 200)]
    public async Task<IEnumerable<ProcessResource>> GetAllAsync()
    {
        var recruitmentProcesses = await _processService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Process>, IEnumerable<ProcessResource>>(recruitmentProcesses);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveProcessResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var recruitmentProcess = _mapper.Map<SaveProcessResource, Process>(resource);
        var result = await _processService.SaveAsync(recruitmentProcess);

        if (!result.Success)
            return BadRequest(result.Message);

        var recruitmentProcessResource = _mapper.Map<Process, ProcessResource>(result.Resource);
        return Created(nameof(PostAsync), recruitmentProcessResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProcessResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var recruitmentProcess = _mapper.Map<SaveProcessResource, Process>(resource);
        var result = await _processService.UpdateAsync(id, recruitmentProcess);

        if (!result.Success)
            return BadRequest(result.Message);

        var recruitmentProcessResource = _mapper.Map<Process, ProcessResource>(result.Resource);
        return Ok(recruitmentProcessResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _processService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var recruitmentProcessResource = _mapper.Map<Process, ProcessResource>(result.Resource);
        return Ok(recruitmentProcessResource);
    }
}