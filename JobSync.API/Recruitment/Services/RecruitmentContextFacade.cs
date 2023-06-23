using JobSync.API.Recruitment.Domain.Services;
using JobSync.API.Recruitment.Interfaces.Internal;

namespace JobSync.API.Recruitment.Services;

public class RecruitmentContextFacade: IRecruitmentContextFacade
{
    private readonly IProcessService _processService;

    public int PhasesByProcessId(int processId)
    {
        return _processService.FindByIdAsync(processId).Result.Phases.Count();
    }

    public int CandidatesByProcessId(int processId)
    {
        return _processService.FindByIdAsync(processId).Result.Phases
            .Sum(phase => phase.ProfileIds.Count());
    }
}