using System.Net.Mime;
using AutoMapper;
using JobSync.API.Organization.Domain.Services;
using JobSync.API.Organization.Resources;
using JobSync.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace JobSync.API.Organization.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/enterprise/organizations")]
[Produces(MediaTypeNames.Application.Json)]

public class OrganizationController : ControllerBase
{
    private readonly IOrganizationService _organizationService;
    private readonly IMapper _mapper;
    
    public OrganizationController(IOrganizationService profileService, IMapper mapper)
    {
        _organizationService = profileService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<OrganizationResource>), 200)]
    public async Task<IEnumerable<OrganizationResource>> GetAllAsync()
    {
        var organizations = await _organizationService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Domain.Models.Organization>, IEnumerable<OrganizationResource>>(organizations);
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] OrganizationResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var organization = _mapper.Map<OrganizationResource, Domain.Models.Organization>(resource);
        var result = await _organizationService.SaveAsync(organization);

        if (!result.Success)
            return BadRequest(result.Message);

        var profileResource = _mapper.Map<Domain.Models.Organization, OrganizationResource>(result.Resource);

        return Created(nameof(PostAsync), profileResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] OrganizationResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var organization = _mapper.Map<OrganizationResource, Domain.Models.Organization>(resource);
        var result = await _organizationService.UpdateAsync(id, organization);

        if (!result.Success)
            return BadRequest(result.Message);

        var organizationResource = _mapper.Map<Domain.Models.Organization, OrganizationResource>(result.Resource);

        return Ok(organizationResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await  _organizationService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var organizationResource = _mapper.Map<Domain.Models.Organization, OrganizationResource>(result.Resource);
        return Ok(organizationResource);
    }
    
}