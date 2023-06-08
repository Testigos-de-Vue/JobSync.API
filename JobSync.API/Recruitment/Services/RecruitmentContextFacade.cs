using JobSync.API.Recruitment.Domain.Repositories;
using JobSync.API.Recruitment.Interfaces.Internal;
using JobSync.API.Recruitment.Persistence.Repositories;

namespace JobSync.API.Recruitment.Services;

public class RecruitmentContextFacade: IRecruitmentContextFacade
{
    private readonly IPhaseRepository _phaseRepository;

    public int TotalPhasesPerProcessId(int processId)
    {
        return _phaseRepository.FinByProcessIdAsync(processId).Result.Count();
    }

    public int TotalCandidatesPerProcessId(int processId)
    {
        throw new NotImplementedException();
    }
}