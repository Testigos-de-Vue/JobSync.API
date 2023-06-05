using System.Diagnostics;

namespace JobSync.API.Recruitment.Domain.Repositories;

public interface IProcessRepository
{
    Task<IEnumerable<Process>>ListAsync();
    Task AddAsync(Process process);
    Task<Process> FindByIdAsync(int processId);
    Task<Process> FindByPhaseIdAsync(int phaseId);
    void Update(Process process);
    void Remove(Process process);
}