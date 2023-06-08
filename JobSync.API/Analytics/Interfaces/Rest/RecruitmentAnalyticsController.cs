using JobSync.API.Analytics.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobSync.API.Analytics.Interfaces.Rest;

[ApiController]
[Route("/api/v1/analytics/recruitment")]
public class RecruitmentAnalyticsController
{
    private readonly IRecruitmentAnalyticsService _recruitmentAnalyticsService;

    public RecruitmentAnalyticsController(IRecruitmentAnalyticsService recruitmentAnalyticsService)
    {
        _recruitmentAnalyticsService = recruitmentAnalyticsService;
    }

    [HttpGet("process/{processId}/phases")]
    public int GetPhasesCountByProcessId(int processId)
    {
        return _recruitmentAnalyticsService.PhasesCountByProcessId(processId);
    }
}