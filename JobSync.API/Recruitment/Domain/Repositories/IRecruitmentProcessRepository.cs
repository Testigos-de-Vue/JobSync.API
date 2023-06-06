using JobSync.API.Recruitment.Domain.Models;

namespace JobSync.API.Recruitment.Domain.Repositories;

public interface IRecruitmentProcessRepository
{
    Task<IEnumerable<RecruitmentProcess>>ListAsync();
    Task AddAsync(RecruitmentProcess recruitmentProcess);
    Task<RecruitmentProcess> FindByIdAsync(int processId);
    void Update(RecruitmentProcess recruitmentProcess);
    void Remove(RecruitmentProcess recruitmentProcess);
}