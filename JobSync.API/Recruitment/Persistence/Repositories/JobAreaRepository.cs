using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Recruitment.Domain.Repositories;
using JobSync.API.Shared.Persistence.Contexts;
using JobSync.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobSync.API.Recruitment.Persistence.Repositories;

public class JobAreaRepository: BaseRepository, IJobAreaRepository
{
    public JobAreaRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<JobArea>> ListAsync()
    {
        return await Context.JobAreas.ToListAsync();
    }

    public async Task AddAsync(JobArea jobArea)
    {
        await Context.JobAreas.AddAsync(jobArea);
    }

    public async Task<JobArea> FindByIdAsync(int id)
    {
        return await Context.JobAreas.FindAsync(id);
    }

    public async Task<JobArea> FindByNameAsync(string name)
    {
        return await Context.JobAreas
            .FirstOrDefaultAsync(j => j.Name == name);
    }
    
    public void Update(JobArea jobArea)
    {
        Context.JobAreas.Update(jobArea);
    }

    public void Remove(JobArea jobArea)
    {
        Context.JobAreas.Remove(jobArea);
    }
}