﻿using System.Net.Mime;
using AutoMapper;
using JobSync.API.Authentication.Domain.Models;
using JobSync.API.Authentication.Domain.Services;
using JobSync.API.Authentication.Resources;
using JobSync.API.Shared.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace JobSync.API.Authentication.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class UsersController : ControllerBase
{
  private readonly IUserService _userService;
  private readonly IMapper _mapper;
  
  public UsersController(IUserService userService, IMapper mapper)
  {
    _userService = userService;
    _mapper = mapper;
  }
  
  [HttpGet]
  [ProducesResponseType(typeof(IEnumerable<UserResource>), 200)]
  public async Task<IEnumerable<UserResource>> GetAllAsync()
  {
    var users = await _userService.ListAsync();
    var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
    return resources;
  }

  [HttpPost]
  public async Task<IActionResult> PostAsync([FromBody] UserResource resource)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState.GetErrorMessages());

    var user = _mapper.Map<UserResource, User>(resource);
    var result = await _userService.CreateAsync(user);
    
    if (!result.Success)
      return BadRequest(result.Message);

    var userResource = _mapper.Map<User, UserResource>(result.Resource);
    
    return Created(nameof(PostAsync), userResource);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> PutAsync(int id, [FromBody] UserResource resource)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState.GetErrorMessages());

    var user = _mapper.Map<UserResource, User>(resource);
    var result = await _userService.UpdateAsync(id, user);
    
    if (!result.Success)
      return BadRequest(result.Message);

    var userResource = _mapper.Map<User, UserResource>(result.Resource);
    
    return Ok(userResource);
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteAsync(int id)
  {
    var result = await _userService.DeleteAsync(id);
    
    if (!result.Success)
      return BadRequest(result.Message);

    var userResource = _mapper.Map<User, UserResource>(result.Resource);
    
    return Ok(userResource);
  }
}