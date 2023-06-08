namespace JobSync.API.Recruitment.Interfaces.Internal;

public interface IRecruitmentContextFacade
{
    int PhasesByProcessId(int processId);
    int CandidatesByProcessId(int processId);
}