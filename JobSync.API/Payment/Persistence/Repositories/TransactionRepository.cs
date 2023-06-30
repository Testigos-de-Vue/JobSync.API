using JobSync.API.Payment.Domain.Models;
using JobSync.API.Payment.Domain.Repositories;
using JobSync.API.Shared.Persistence.Contexts;
using JobSync.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobSync.API.Payment.Persistence.Repositories;

public class TransactionRepository : BaseRepository, ITransactionRepository
{
    public TransactionRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Transaction>> ListAsync()
    {
        return await Context.Transactions.ToListAsync();
    }

    public async Task AddAsync(Transaction transaction)
    {
        await Context.Transactions.AddAsync(transaction);
    }

    public async Task<Transaction> FindByIdAsync(int id)
    {
        return await Context.Transactions.FindAsync(id);
    }

    public void Update(Transaction transaction)
    {
        Context.Transactions.Update(transaction);
    }

    public void Remove(Transaction transaction)
    {
        Context.Transactions.Remove(transaction);
    }
}