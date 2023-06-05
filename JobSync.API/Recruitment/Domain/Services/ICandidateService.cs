using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Domain.Services.Communication;

namespace JobSync.API.Recruitment.Domain.Services;

public interface ICandidateService
{
    Task<IEnumerable<Candidate>> ListAsync();
    Task<CandidateReponse>SaveAsync(Candidate candidate);
    Task<CandidateReponse> UpdateAsync(int id, Candidate candidate);
    Task<CandidateReponse> DeleteAsync(int id);
}