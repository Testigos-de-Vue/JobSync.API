using JobSync.API.Payment.Domain.Models;
using JobSync.API.Payment.Domain.Repositories;
using JobSync.API.Payment.Domain.Services;
using JobSync.API.Payment.Domain.Services.Communication;
using JobSync.API.Shared.Domain.Repositories;

namespace JobSync.API.Payment.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public TransactionService(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork)
    {
        _transactionRepository = transactionRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Transaction>> ListAsync()
    {
        return await _transactionRepository.ListAsync();
    }

    public async Task<TransactionResponse> CreateAsync(Transaction transaction)
    {
        try
        {
            await _transactionRepository.AddAsync(transaction);
            await _unitOfWork.CompleteAsync();
      
            return new TransactionResponse(transaction);
        }
        catch (Exception e)
        {
            return new TransactionResponse($"An error occurred while saving this payment: {e.Message}");
        }
    }

    public async Task<TransactionResponse> DeleteAsync(int id)
    {
        var existingTransaction = await _transactionRepository.FindByIdAsync(id);

        if (existingTransaction == null)
            return new TransactionResponse("Pay not found");

        try
        {
            _transactionRepository.Remove(existingTransaction);
            await _unitOfWork.CompleteAsync();

            return new TransactionResponse(existingTransaction);
        }
        catch (Exception e)
        {
            return new TransactionResponse($"An error occurred while deleting this pay: {e.Message}");
        }
    }
}