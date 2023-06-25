using JobSync.API.Organization.Domain.Repositories;
using JobSync.API.Shared.Persistence.Contexts;
using JobSync.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobSync.API.Organization.Persistence.Repositories;

public class OrganizationRepository : BaseRepository, IOrganizationRepository
{
    public OrganizationRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Domain.Models.Organization>> ListAsync()
    {
        return await Context.Organizations.ToListAsync();
    }
    
    public async Task AddAsync(Domain.Models.Organization organization)
    {
        await Context.Organizations.AddAsync(organization);
    }
    
    public async Task<Domain.Models.Organization> FindByIdAsync(int id)
    {
        return await Context.Organizations
            .FirstOrDefaultAsync(o => o.Id == id);
    }
    
    public async Task<List<int>> GetProfileIdsByOrganizationId(int organizationId)
    {
        var organization = await Context.Organizations
            .FirstOrDefaultAsync(o => o.Id == organizationId);

        if (organization != null)
        {
            return organization.ProfileIds;
        }
        return new List<int>(); 
    }
    
    public async Task<Domain.Models.Organization> FindByNameAsync(string name)
    {
        return await Context.Organizations
            .FirstOrDefaultAsync(p => p.Name == name);
    }
    
    public void Update(Domain.Models.Organization organization)
    {
        Context.Organizations.Update(organization);
    }
    
    public void Remove(Domain.Models.Organization organization)
    {
        Context.Organizations.Remove(organization);
    }
}