using JobSync.API.Payment.Domain.Models;
using JobSync.API.Payment.Domain.Repositories;
using JobSync.API.Shared.Persistence.Contexts;
using JobSync.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobSync.API.Payment.Persistence.Repositories;

public class PayRepository : BaseRepository, IPayRepository
{
    public PayRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Pay>> ListAsync()
    {
        return await Context.Pays.ToListAsync();
    }

    public async Task AddAsync(Pay pay)
    {
        await Context.Pays.AddAsync(pay);
    }

    public async Task<Pay> FindByIdAsync(int id)
    {
        return await Context.Pays.FindAsync(id);
    }

    public void Update(Pay pay)
    {
        Context.Pays.Update(pay);
    }

    public void Remove(Pay pay)
    {
        Context.Pays.Remove(pay);
    }
}