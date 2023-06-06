using JobSync.API.Recruitment.Domain.Models;

namespace JobSync.API.Recruitment.Domain.Repositories;

public interface ICandidateProfileRepository
{
    Task<IEnumerable<CandidateProfile>>ListAsync();
    Task AddAsync(CandidateProfile candidateProfile);
    Task<CandidateProfile> FindByIdAsync(int candidateId);
    Task<IEnumerable<CandidateProfile>> FindByJobAreaIdAsync(int jobAreaId);
    Task<IEnumerable<CandidateProfile>> FindByUserIdAsync(int userId);
    Task<IEnumerable<CandidateProfile>> FindByRecruitmentPhaseIdAsync(int phaseId);
    void Update(CandidateProfile candidateProfile);
    void Remove(CandidateProfile candidateProfile);
}