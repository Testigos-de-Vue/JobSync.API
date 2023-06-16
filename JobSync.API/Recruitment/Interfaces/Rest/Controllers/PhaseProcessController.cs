using System.Net.Mime;
using AutoMapper;
using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Domain.Services;
using JobSync.API.Recruitment.Resources;
using Microsoft.AspNetCore.Mvc;

namespace JobSync.API.Recruitment.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/proccess/{processId}/phases")]
[Produces(MediaTypeNames.Application.Json)]
public class PhaseProcessController: ControllerBase
{
    private readonly IPhaseService _phaseService;
    private readonly IMapper _mapper;
    
    public PhaseProcessController(IPhaseService phaseService, IMapper mapper)
    {
        _phaseService = phaseService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<PhaseResource>> GetAllByProcessId(int processId)
    {
        var phases = await _phaseService.ListByProcessIdAsync(processId);
        var resources = _mapper.Map<IEnumerable<Phase>, IEnumerable<PhaseResource>>(phases);
        return resources;
    }
}