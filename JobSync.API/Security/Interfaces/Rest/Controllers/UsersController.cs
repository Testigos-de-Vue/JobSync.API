using System.Net.Mime;

using AutoMapper;
using JobSync.API.Security.Authorization.Attributes;
using JobSync.API.Security.Domain.Models;
using JobSync.API.Security.Domain.Services;
using JobSync.API.Security.Domain.Services.Communication;
using JobSync.API.Security.Resources;
using Microsoft.AspNetCore.Mvc;

namespace JobSync.API.Security.Interfaces.Rest.Controllers;

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
  
  [AllowAnonymous]
  [HttpPost("sign-in")]
  public async Task<IActionResult> Authenticate(AuthenticateRequest request)
  {
    var response = await _userService.AuthenticateAsync(request);
    return Ok(response);
  }

  [HttpPost("sign-up")]
  public async Task<IActionResult> Register(RegisterRequest request)
  {
    await _userService.RegisterAsync(request);
    return Ok(new { message = "Registration successful" });
  }

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    var users = await _userService.ListAsync();
    var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
    return Ok(resources);
  }
}
