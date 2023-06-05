using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Domain.Services.Communication;

namespace JobSync.API.Recruitment.Domain.Services;

public interface IPhaseService
{
    Task<IEnumerable<Phase>> ListAsync();
    Task<PhaseReponse> SaveAsync(Phase phase);
    Task<PhaseReponse> UpdateAsync(int id, Phase phase);
    Task<PhaseReponse> DeleteAsync(int id);
}