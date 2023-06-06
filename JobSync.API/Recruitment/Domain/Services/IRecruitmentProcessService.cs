using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Domain.Services.Communication;

namespace JobSync.API.Recruitment.Domain.Services;

public interface IRecruitmentProcessService
{
    Task<IEnumerable<RecruitmentProcess>> ListAsync();
    Task<RecruitmentProcessResponse> SaveAsync(RecruitmentProcess recruitmentProcess);
    Task<RecruitmentProcessResponse> UpdateAsync(int id, RecruitmentProcess recruitmentProcess);
    Task<RecruitmentProcessResponse> DeleteAsync(int id);
}