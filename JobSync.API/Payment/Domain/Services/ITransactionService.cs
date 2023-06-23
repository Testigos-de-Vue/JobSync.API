using JobSync.API.Payment.Domain.Models;
using JobSync.API.Payment.Domain.Services.Communication;

namespace JobSync.API.Payment.Domain.Services;

public interface ITransactionService
{
    Task<IEnumerable<Transaction>> ListAsync();
    Task<TransactionResponse> CreateAsync(Transaction transaction);
    Task<TransactionResponse> DeleteAsync(int id);
}