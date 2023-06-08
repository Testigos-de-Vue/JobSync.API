namespace JobSync.API.Analytics.Domain.Services;

public interface IRecruitmentAnalyticsService
{
    int PhasesCountByProcessId(int processId);
}