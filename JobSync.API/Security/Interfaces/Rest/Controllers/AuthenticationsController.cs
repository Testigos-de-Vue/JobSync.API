
﻿using System.Net.Mime;
using JobSync.API.Authentication.Domain.Services;
using JobSync.API.Authentication.Domain.Services.Communication;
using Microsoft.AspNetCore.Mvc;

namespace JobSync.API.Authentication.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class AuthenticationsController : ControllerBase
{
  private readonly IAuthenticationService _authenticationService;

  public AuthenticationsController(IAuthenticationService authenticationService)
  {
    _authenticationService = authenticationService;
  }

  [HttpPost]
  public async Task<IActionResult> PostAsync([FromBody] AuthenticateRequest request)
  {
    try
    {
      var response = await _authenticationService.Authenticate(request);
      return Ok(Response);
    }
    catch (Exception e)
    {
      return BadRequest($"Authentication failed: {e.Message}");
    }
  }
}

