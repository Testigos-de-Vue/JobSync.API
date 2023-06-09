using JobSync.API.Organization.Domain.Services.Communication;
using JobSync.API.Organization.Domain.Models;
namespace JobSync.API.Organization.Domain.Services;

public interface IPlanService
{
    Task<IEnumerable<Plan>> ListAsync();
    Task<PlanResponse> SaveAsync(Plan plan);
    Task<PlanResponse> UpdateAsync(int planId, Plan plan);
    Task<PlanResponse> DeleteAsync(int planId);
}