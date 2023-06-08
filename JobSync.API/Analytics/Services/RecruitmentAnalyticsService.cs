using JobSync.API.Analytics.Domain.Services;
using JobSync.API.Recruitment.Interfaces.Internal;

namespace JobSync.API.Analytics.Services;

public class RecruitmentAnalyticsService: IRecruitmentAnalyticsService
{
    private readonly IRecruitmentContextFacade _recruitmentContext;

    public RecruitmentAnalyticsService(IRecruitmentContextFacade recruitmentContext)
    {
        _recruitmentContext = recruitmentContext;
    }
    
    public int PhasesCountByProcessId(int processId)
    {
        return _recruitmentContext.PhasesByProcessId(processId);
    }
}