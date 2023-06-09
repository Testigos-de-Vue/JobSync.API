using System.Net.Mime;
using AutoMapper;
using JobSync.API.Organization.Domain.Services;
using JobSync.API.Organization.Resources;
using JobSync.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace JobSync.API.Organization.Interfaces.Rest.Controllers;


[ApiController]
[Route("api/v1/plans")]
[Produces(MediaTypeNames.Application.Json)]

public class PlanController : ControllerBase
{
    
    private readonly IPlanService _planService;
    private readonly IMapper _mapper;
    
    public PlanController(IPlanService profileService, IMapper mapper)
    {
        _planService = profileService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<PlanResource>), 200)]
    public async Task<IEnumerable<PlanResource>> GetAllAsync()
    {
        var plans = await _planService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Domain.Models.Plan>, IEnumerable<PlanResource>>(plans);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] PlanResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var plan = _mapper.Map<PlanResource, Domain.Models.Plan>(resource);
        var result = await _planService.SaveAsync(plan);

        if (!result.Success)
            return BadRequest(result.Message);

        var planResource = _mapper.Map<Domain.Models.Plan, PlanResource>(result.Resource);

        return Created(nameof(PostAsync), planResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] PlanResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var plan = _mapper.Map<PlanResource, Domain.Models.Plan>(resource);
        var result = await _planService.UpdateAsync(id, plan);

        if (!result.Success)
            return BadRequest(result.Message);

        var planResource = _mapper.Map<Domain.Models.Plan, PlanResource>(result.Resource);

        return Ok(planResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await  _planService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var organizationResource = _mapper.Map<Domain.Models.Plan, PlanResource>(result.Resource);
        return Ok(organizationResource);
    }
}