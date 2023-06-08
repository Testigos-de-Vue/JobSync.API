namespace JobSync.API.Recruitment.Interfaces.Internal;

public interface IRecruitmentContextFacade
{
    int TotalPhasesPerProcessId(int processId);
    int TotalCandidatesPerProcessId(int processId);
}