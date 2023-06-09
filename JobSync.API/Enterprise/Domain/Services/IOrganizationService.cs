using JobSync.API.Organization.Domain.Services.Communication;

namespace JobSync.API.Organization.Domain.Services;

public interface IOrganizationService
{
    Task<IEnumerable<Models.Organization>> ListAsync();
    Task<OrganizationResponse> SaveAsync(Models.Organization organization);
    Task<OrganizationResponse> UpdateAsync(int id, Models.Organization organization);
    Task<OrganizationResponse> DeleteAsync(int id);
}