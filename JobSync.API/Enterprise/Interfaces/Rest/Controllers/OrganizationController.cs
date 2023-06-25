using System.Net.Mime;
using AutoMapper;
using JobSync.API.Organization.Domain.Services;
using JobSync.API.Organization.Resources;
using JobSync.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JobSync.API.Organization.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/enterprise/organizations")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Create, read, update and delete Organizations")]

public class OrganizationController : ControllerBase
{
    private readonly IOrganizationService _organizationService;
    private readonly IMapper _mapper;
    
    public OrganizationController(IOrganizationService organizationService, IMapper mapper)
    {
        _organizationService = organizationService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<OrganizationResource>), 200)]
    [SwaggerOperation(
        Summary = "Get All Organizations",
        Description = "Get All Organizations",
        OperationId = "GetAllOrganizations")]
    public async Task<IEnumerable<OrganizationResource>> GetAllAsync()
    {
        var organizations = await _organizationService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Domain.Models.Organization>, IEnumerable<OrganizationResource>>(organizations);
        return resources;
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(IEnumerable<OrganizationResource>), 200)]
    [SwaggerOperation(
        Summary = "Get Organization by Id",
        Description = "Get Organization by Id",
        OperationId = "GetOrganizationById")]
    public async Task<OrganizationResource> GetByIdAsync(int id)
    {
        var organization = await _organizationService.FindByIdAsync(id);
        var resource = _mapper.Map<Domain.Models.Organization, OrganizationResource>(organization);
        return resource;
    }
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create new Organization",
        Description = "Create new Organization",
        OperationId = "PostOrganization")]
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

        var organizationResource = _mapper.Map<Domain.Models.Organization, OrganizationResource>(result.Resource);

        return Created(nameof(PostAsync), organizationResource);
    }
        
    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Update Organization by Id",
        Description = "Update Organization by Id",
        OperationId = "PutOrganization")]
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
    [SwaggerOperation(
        Summary = "Delete Organization by Id",
        Description = "Delete Organization by Id",
        OperationId = "DeleteOrganization")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await  _organizationService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var organizationResource = _mapper.Map<Domain.Models.Organization, OrganizationResource>(result.Resource);
        return Ok(organizationResource);
    }
}