using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Domain.Services.Communication;
using JobSync.API.Recruitment.Persistence.Repositories;

namespace JobSync.API.Recruitment.Domain.Services;

public interface IPhaseService
{
    Task<IEnumerable<Phase>> ListAsync();
    Task<PhaseResponse> SaveAsync(Phase phase);
    Task<PhaseResponse> UpdateAsync(int id, Phase phase);
    Task<PhaseResponse> DeleteAsync(int id);
    Task<PhaseResponse> PhaseCountByProcessIdAsync(int processId);
    Task<IEnumerable<Phase>> ListByProcessIdAsync(int processId);
}