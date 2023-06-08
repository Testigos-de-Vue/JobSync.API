using JobSync.API.Recruitment.Domain.Models;

namespace JobSync.API.Recruitment.Domain.Repositories;

public interface IPhaseRepository
{
    Task<IEnumerable<Phase>>ListAsync();
    Task AddAsync(Phase phase);
    Task<Phase> FindByIdAsync(int phaseId);
    Task<IEnumerable<Phase>> FinByProcessIdAsync(int processId);
    void Update(Phase phase);
    void Remove(Phase phase);
}