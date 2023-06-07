using AutoMapper;
using JobSync.API.Profile.Domain.Models;
using JobSync.API.Profile.Domain.Services;
using JobSync.API.Profile.Domain.Services.Communication;
using JobSync.API.Profile.Resources;
using JobSync.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace JobSync.API.Profile.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/roles")]
public class RoleController : ControllerBase
{
  private readonly IRoleService _roleService;
  private readonly IMapper _mapper;
  
  public RoleController(IRoleService roleService, IMapper mapper)
  {
    _roleService = roleService;
    _mapper = mapper;
  }

  [HttpGet]
  [ProducesResponseType(typeof(IEnumerable<RoleResource>), 200)]
  public async Task<IEnumerable<RoleResource>> GetAllAsync()
  {
    var roles = await _roleService.ListAsync();
    var resources = _mapper.Map<IEnumerable<Role>, IEnumerable<RoleResource>>(roles);
    return resources;
  }

  [HttpPost]
  public async Task<IActionResult> PostAsync([FromBody] SaveRoleResource resource)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState.GetErrorMessages());
    }

    var role = _mapper.Map<SaveRoleResource, Role>(resource);
    var result = await _roleService.SaveAsync(role);

    if (!result.Success)
      return BadRequest(result.Message);

    var roleResource = _mapper.Map<Role, RoleResource>(result.Resource);

    return Created(nameof(PostAsync), roleResource);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRoleResource resource)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest(ModelState.GetErrorMessages());
    }

    var role = _mapper.Map<SaveRoleResource, Role>(resource);
    var result = await _roleService.UpdateAsync(id, role);

    if (!result.Success)
      return BadRequest(result.Message);

    var roleResource = _mapper.Map<Role, RoleResponse>(result.Resource);

    return Ok(roleResource);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteAsync(int id)
  {
    var result = await _roleService.DeleteAsync(id);

    if (!result.Success)
      return BadRequest(result.Message);

    var roleResource = _mapper.Map<Role, RoleResource>(result.Resource);

    return Ok(roleResource);
  }
}