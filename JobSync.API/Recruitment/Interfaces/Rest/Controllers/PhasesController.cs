using System.Net.Mime;
using AutoMapper;
using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Domain.Services;
using JobSync.API.Recruitment.Resources;
using JobSync.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace JobSync.API.Recruitment.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/recruitment/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class PhasesController: ControllerBase
{
    private readonly IPhaseService _phaseService;
    private readonly IMapper _mapper;
    
    public PhasesController(IPhaseService phaseService, IMapper mapper)
    {
        _phaseService = phaseService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<PhaseResource>), 200)]
    public async Task<IEnumerable<PhaseResource>> GetAllAsync()
    {
        var recruitmentPhases = await _phaseService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Phase>, IEnumerable<PhaseResource>>(recruitmentPhases);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SavePhaseResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var recruitmentPhase = _mapper.Map<SavePhaseResource, Phase>(resource);
        var result = await _phaseService.SaveAsync(recruitmentPhase);

        if (!result.Success)
            return BadRequest(result.Message);

        var recruitmentPhaseResource = _mapper.Map<Phase, PhaseResource>(result.Resource);
        return Created(nameof(PostAsync), recruitmentPhaseResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SavePhaseResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var recruitmentPhase = _mapper.Map<SavePhaseResource, Phase>(resource);
        var result = await _phaseService.UpdateAsync(id, recruitmentPhase);

        if (!result.Success)
            return BadRequest(result.Message);

        var recruitmentPhaseResource = _mapper.Map<Phase, PhaseResource>(result.Resource);
        return Ok(recruitmentPhaseResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _phaseService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var recruitmentPhaseResource = _mapper.Map<Phase, PhaseResource>(result.Resource);
        return Ok(recruitmentPhaseResource);
    }
}