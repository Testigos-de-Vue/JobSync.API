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
        return await Context.Organizations.FindAsync(id);
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