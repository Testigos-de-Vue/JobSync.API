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
public class RecruitmentPhasesController: ControllerBase
{
    private readonly IRecruitmentPhaseService _recruitmentPhaseService;
    private readonly IMapper _mapper;
    
    public RecruitmentPhasesController(IRecruitmentPhaseService recruitmentPhaseService, IMapper mapper)
    {
        _recruitmentPhaseService = recruitmentPhaseService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<RecruitmentPhaseResource>), 200)]
    public async Task<IEnumerable<RecruitmentPhaseResource>> GetAllAsync()
    {
        var recruitmentPhases = await _recruitmentPhaseService.ListAsync();
        var resources = _mapper.Map<IEnumerable<RecruitmentPhase>, IEnumerable<RecruitmentPhaseResource>>(recruitmentPhases);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveRecruitmentPhaseResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var recruitmentPhase = _mapper.Map<SaveRecruitmentPhaseResource, RecruitmentPhase>(resource);
        var result = await _recruitmentPhaseService.SaveAsync(recruitmentPhase);

        if (!result.Success)
            return BadRequest(result.Message);

        var recruitmentPhaseResource = _mapper.Map<RecruitmentPhase, RecruitmentPhaseResource>(result.Resource);
        return Created(nameof(PostAsync), recruitmentPhaseResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRecruitmentPhaseResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var recruitmentPhase = _mapper.Map<SaveRecruitmentPhaseResource, RecruitmentPhase>(resource);
        var result = await _recruitmentPhaseService.UpdateAsync(id, recruitmentPhase);

        if (!result.Success)
            return BadRequest(result.Message);

        var recruitmentPhaseResource = _mapper.Map<RecruitmentPhase, RecruitmentPhaseResource>(result.Resource);
        return Ok(recruitmentPhaseResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _recruitmentPhaseService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var recruitmentPhaseResource = _mapper.Map<RecruitmentPhase, RecruitmentPhaseResource>(result.Resource);
        return Ok(recruitmentPhaseResource);
    }
}