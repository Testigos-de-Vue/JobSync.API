using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Domain.Services.Communication;

namespace JobSync.API.Recruitment.Domain.Services;

public interface ICandidateProfileService
{
    Task<IEnumerable<CandidateProfile>> ListAsync();
    Task<CandidateProfileReponse>SaveAsync(CandidateProfile candidateProfile);
    Task<CandidateProfileReponse> UpdateAsync(int id, CandidateProfile candidateProfile);
    Task<CandidateProfileReponse> DeleteAsync(int id);
}