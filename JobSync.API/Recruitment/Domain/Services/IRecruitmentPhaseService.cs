using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Domain.Services.Communication;

namespace JobSync.API.Recruitment.Domain.Services;

public interface IRecruitmentPhaseService
{
    Task<IEnumerable<RecruitmentPhase>> ListAsync();
    Task<RecruitmentPhaseReponse> SaveAsync(RecruitmentPhase recruitmentPhase);
    Task<RecruitmentPhaseReponse> UpdateAsync(int id, RecruitmentPhase recruitmentPhase);
    Task<RecruitmentPhaseReponse> DeleteAsync(int id);
}