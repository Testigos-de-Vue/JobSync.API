using JobSync.API.Recruitment.Domain.Models;

namespace JobSync.API.Recruitment.Domain.Repositories;

public interface IProcessRepository
{
    Task<IEnumerable<Process>>ListAsync();
    Task AddAsync(Process process);
    Task<Process> FindByIdAsync(int processId);
    void Update(Process process);
    void Remove(Process process);
}