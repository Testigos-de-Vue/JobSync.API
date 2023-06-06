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
public class CandidatesController: ControllerBase
{
    private readonly ICandidateProfileService _candidateProfileService;
    private readonly IMapper _mapper;
    
    public CandidatesController(ICandidateProfileService candidateProfileService, IMapper mapper)
    {
        _candidateProfileService = candidateProfileService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CandidateProfileResource>), 200)]
    public async Task<IEnumerable<CandidateProfileResource>> GetAllAsync()
    {
        var candidates = await _candidateProfileService.ListAsync();
        var resources = _mapper.Map<IEnumerable<CandidateProfile>, IEnumerable<CandidateProfileResource>>(candidates);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveCandidateProfileResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var candidateProfile = _mapper.Map<SaveCandidateProfileResource, CandidateProfile>(resource);
        var result = await _candidateProfileService.SaveAsync(candidateProfile);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var candidateProfileResource = _mapper.Map<CandidateProfile, CandidateProfileResource>(result.Resource);
        return Created(nameof(PostAsync), candidateProfileResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCandidateProfileResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var candidateProfile = _mapper.Map<SaveCandidateProfileResource, CandidateProfile>(resource);
        var result = await _candidateProfileService.UpdateAsync(id, candidateProfile);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var candidateProfileResource = _mapper.Map<CandidateProfile, CandidateProfileResource>(result.Resource);
        return Ok(candidateProfileResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _candidateProfileService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var candidateProfileResource = _mapper.Map<CandidateProfile, CandidateProfileResource>(result.Resource);
        return Ok(candidateProfileResource);
    }
}