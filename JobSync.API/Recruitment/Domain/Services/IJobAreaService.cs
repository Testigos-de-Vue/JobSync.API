using JobSync.API.Recruitment.Domain.Models;

namespace JobSync.API.Recruitment.Domain.Services.Communication;

public interface IJobAreaService
{
    Task<IEnumerable<JobArea>> ListAsync();
    Task<JobAreaResponse> SaveAsync(JobArea jobArea);
    Task<JobAreaResponse> UpdateAsync(int id, JobArea jobArea);
    Task<JobAreaResponse> DeleteAsync(int id);
}