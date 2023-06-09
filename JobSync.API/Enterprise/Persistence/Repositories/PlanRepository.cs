using JobSync.API.Organization.Domain.Repositories;
using JobSync.API.Shared.Persistence.Contexts;
using JobSync.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobSync.API.Organization.Persistence.Repositories;

public class PlanRepository: BaseRepository, IPlanRepository
{
    public PlanRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Domain.Models.Plan>> ListAsync()
    {
        return await Context.Plans.ToListAsync();
    }
    
    public async Task AddAsync(Domain.Models.Plan plan)
    {
        await Context.Plans.AddAsync(plan);
    }
    
    public async Task<Domain.Models.Plan> FindByIdAsync(int id)
    {
        return await Context.Plans.FindAsync(id);
    }
    
    public async Task<Domain.Models.Plan> FindByNameAsync(string name)
    {
        return await Context.Plans
            .FirstOrDefaultAsync(p => p.Name == name);
    }
    
    public void Update(Domain.Models.Plan plan)
    {
        Context.Plans.Update(plan);
    }
    
    public void Remove(Domain.Models.Plan plan)
    {
        Context.Plans.Remove(plan);
    }
}