using JobSync.API.Recruitment.Domain.Models;

namespace JobSync.API.Recruitment.Domain.Repositories;

public interface IRecruitmentPhaseRepository
{
    Task<IEnumerable<RecruitmentPhase>>ListAsync();
    Task AddAsync(RecruitmentPhase recruitmentPhase);
    Task<RecruitmentPhase> FindByIdAsync(int phaseId);
    Task<IEnumerable<RecruitmentPhase>> FinByProcessIdAsync(int processId);
    void Update(RecruitmentPhase recruitmentPhase);
    void Remove(RecruitmentPhase recruitmentPhase);
}