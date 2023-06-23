using JobSync.API.Payment.Domain.Models;

namespace JobSync.API.Payment.Domain.Repositories;

public interface ITransactionRepository
{
    Task<IEnumerable<Transaction>> ListAsync();
    Task AddAsync(Transaction transaction);
    Task<Transaction> FindByIdAsync(int id);
    void Update(Transaction transaction);
    void Remove(Transaction transaction);
}