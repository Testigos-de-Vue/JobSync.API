using System.Net.Mime;
using AutoMapper;
using JobSync.API.Organization.Domain.Services;
using JobSync.API.Profile.Domain.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace JobSync.API.Organization.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/enterprise/organizations/{organizationId}/")]
[Produces(MediaTypeNames.Application.Json)]
public class OrganizationMembersController
{
  
}