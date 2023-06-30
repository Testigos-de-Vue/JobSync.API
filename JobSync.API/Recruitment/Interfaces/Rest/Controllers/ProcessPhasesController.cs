using System.Net.Mime;
using AutoMapper;
using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Domain.Services;
using JobSync.API.Recruitment.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JobSync.API.Recruitment.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/recruitment/processes/{processId}/phases")]
[Produces(MediaTypeNames.Application.Json)]
public class ProcessPhasesController: ControllerBase
{
    private readonly IPhaseService _phaseService;
    private readonly IMapper _mapper;
    
    public ProcessPhasesController(IPhaseService phaseService, IMapper mapper)
    {
        _phaseService = phaseService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Phases by Given Process",
        Description = "Get existing Phases from the Given Process Id",
        OperationId = "GetProcessPhases",
        Tags = new []{"Processes"})]
    public async Task<IEnumerable<PhaseResource>> GetAllByProcessId(int processId)
    {
        var phases = await _phaseService.ListByProcessIdAsync(processId);
        var resources = _mapper.Map<IEnumerable<Phase>, IEnumerable<PhaseResource>>(phases);
        return resources;
    }
}