using System.Net.Mime;
using AutoMapper;
using JobSync.API.Profile.Domain.Services;
using JobSync.API.Profile.Resources;
using JobSync.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace JobSync.API.Profile.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/profiles")]
[Produces(MediaTypeNames.Application.Json)]
public class ProfileController : ControllerBase
{
  private readonly IProfileService _profileService;
  private readonly IMapper _mapper;

  public ProfileController(IProfileService profileService, IMapper mapper)
  {
    _profileService = profileService;
    _mapper = mapper;
  }
  
  [HttpGet]
  [ProducesResponseType(typeof(IEnumerable<ProfileResource>), 200)]
  public async Task<IEnumerable<ProfileResource>> GetAllAsync()
  {
    var profiles = await _profileService.ListAsync();
    var resources = _mapper.Map<IEnumerable<Domain.Models.Profile>, IEnumerable<ProfileResource>>(profiles);
    return resources;
  }

  [HttpPost]
  public async Task<IActionResult> PostAsync([FromBody] SaveProfileResource resource)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState.GetErrorMessages());
    }

    var profile = _mapper.Map<SaveProfileResource, Domain.Models.Profile>(resource);
    var result = await _profileService.SaveAsync(profile);

    if (!result.Success)
      return BadRequest(result.Message);

    var profileResource = _mapper.Map<Domain.Models.Profile, ProfileResource>(result.Resource);

    return Created(nameof(PostAsync), profileResource);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProfileResource resource)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState.GetErrorMessages());
    }

    var profile = _mapper.Map<SaveProfileResource, Domain.Models.Profile>(resource);
    var result = await _profileService.UpdateAsync(id, profile);

    if (!result.Success)
      return BadRequest(result.Message);

    var profileResource = _mapper.Map<Domain.Models.Profile, ProfileResource>(result.Resource);

    return Ok(profileResource);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteAsync(int id)
  {
    var result = await _profileService.DeleteAsync(id);

    if (!result.Success)
      return BadRequest(result.Message);

    var profileResource = _mapper.Map<Domain.Models.Profile, ProfileResource>(result.Resource);

    return Ok(profileResource);
  }
}