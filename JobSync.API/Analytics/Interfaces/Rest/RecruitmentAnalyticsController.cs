using JobSync.API.Analytics.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JobSync.API.Analytics.Interfaces.Rest;

[ApiController]
[Route("/api/v1/recruitment/analytics/processes")]
public class RecruitmentAnalyticsController
{
    private readonly IRecruitmentAnalyticsService _recruitmentAnalyticsService;

    public RecruitmentAnalyticsController(IRecruitmentAnalyticsService recruitmentAnalyticsService)
    {
        _recruitmentAnalyticsService = recruitmentAnalyticsService;
    }

    [HttpGet("{id}/phases/count")]
    [SwaggerOperation(
        Summary = "Get Phases Count By Process Id",
        Description = "Get Number Of Phases By Given Process Id",
        OperationId = "GetPhasesCounter",
        Tags = new []{"Processes"})]
    public int GetPhasesCountByProcessId(int processId)
    {
        return _recruitmentAnalyticsService.PhasesCountByProcessId(processId);
    }
}