namespace JobSync.API.Organization.Domain.Repositories;
using JobSync.API.Organization.Domain.Models;

public interface IOrganizationRepository
{
    Task<IEnumerable<Organization>> ListAsync();
    Task AddAsync(Organization organization);
    Task<Organization> FindByIdAsync(int id);
    Task<List<int>> GetProfileIdsByOrganizationId(int organizationId);
    Task<Organization> FindByNameAsync(string name);
    void Update(Organization organization);
    void Remove(Organization organization);
}