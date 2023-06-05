using JobSync.API.Recruitment.Domain.Models;

namespace JobSync.API.Recruitment.Domain.Repositories;

public interface ICandidateRepository
{
    Task<IEnumerable<Candidate>>ListAsync();
    Task AddAsync(Candidate candidate);
    Task<Candidate> FindByIdAsync(int candidateId);
    Task<Candidate> FindByJobAreaAsync(int jobAreaId);
    void Update(Candidate candidate);
    void Remove(Candidate candidate);
}