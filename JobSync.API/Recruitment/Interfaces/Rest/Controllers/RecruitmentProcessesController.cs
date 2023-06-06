using System.Net.Mime;
using AutoMapper;
using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Domain.Services;
using JobSync.API.Recruitment.Resources;
using JobSync.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace JobSync.API.Recruitment.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class RecruitmentProcessesController: ControllerBase
{
    private readonly IRecruitmentProcessService _recruitmentProcessService;
    private readonly IMapper _mapper;
    
    public RecruitmentProcessesController(IRecruitmentProcessService recruitmentProcessService, IMapper mapper)
    {
        _recruitmentProcessService = recruitmentProcessService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<RecruitmentProcessResource>), 200)]
    public async Task<IEnumerable<RecruitmentProcessResource>> GetAllAsync()
    {
        var recruitmentProcesses = await _recruitmentProcessService.ListAsync();
        var resources = _mapper.Map<IEnumerable<RecruitmentProcess>, IEnumerable<RecruitmentProcessResource>>(recruitmentProcesses);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveRecruitmentProcessResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var recruitmentProcess = _mapper.Map<SaveRecruitmentProcessResource, RecruitmentProcess>(resource);
        var result = await _recruitmentProcessService.SaveAsync(recruitmentProcess);

        if (!result.Success)
            return BadRequest(result.Message);

        var recruitmentProcessResource = _mapper.Map<RecruitmentProcess, RecruitmentProcessResource>(result.Resource);
        return Created(nameof(PostAsync), recruitmentProcessResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRecruitmentProcessResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var recruitmentProcess = _mapper.Map<SaveRecruitmentProcessResource, RecruitmentProcess>(resource);
        var result = await _recruitmentProcessService.UpdateAsync(id, recruitmentProcess);

        if (!result.Success)
            return BadRequest(result.Message);

        var recruitmentProcessResource = _mapper.Map<RecruitmentProcess, RecruitmentProcessResource>(result.Resource);
        return Ok(recruitmentProcessResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _recruitmentProcessService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var recruitmentProcessResource = _mapper.Map<RecruitmentProcess, RecruitmentProcessResource>(result.Resource);
        return Ok(recruitmentProcessResource);
    }
}