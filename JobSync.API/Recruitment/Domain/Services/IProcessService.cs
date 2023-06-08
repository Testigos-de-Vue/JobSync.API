using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Domain.Services.Communication;

namespace JobSync.API.Recruitment.Domain.Services;

public interface IProcessService
{
    Task<IEnumerable<Process>> ListAsync();
    Task<ProcessResponse> SaveAsync(Process process);
    Task<ProcessResponse> UpdateAsync(int id, Process process);
    Task<ProcessResponse> DeleteAsync(int id);
}