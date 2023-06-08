using JobSync.API.Recruitment.Domain.Services;
using JobSync.API.Recruitment.Interfaces.Internal;

namespace JobSync.API.Recruitment.Services;

public class RecruitmentContextFacade: IRecruitmentContextFacade
{
    private readonly IPhaseService _phaseService;

    public int PhasesByProcessId(int processId)
    {
        throw new NotImplementedException();
    }

    public int CandidatesByProcessId(int processId)
    {
        throw new NotImplementedException();
    }
}