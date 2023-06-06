using JobSync.API.Recruitment.Domain.Models;

namespace JobSync.API.Recruitment.Domain.Repositories;

public interface ICandidateProfileRepository
{
    Task<IEnumerable<CandidateProfile>>ListAsync();
    Task AddAsync(CandidateProfile candidateProfile);
    Task<CandidateProfile> FindByIdAsync(int candidateId);
    Task<CandidateProfile> FindByJobAreaAsync(int jobAreaId);
    void Update(CandidateProfile candidateProfile);
    void Remove(CandidateProfile candidateProfile);
}