using JobSync.API.Payment.Domain.Models;
using JobSync.API.Payment.Domain.Repositories;
using JobSync.API.Payment.Domain.Services;
using JobSync.API.Payment.Domain.Services.Communication;
using JobSync.API.Shared.Domain.Repositories;

namespace JobSync.API.Payment.Services;

public class PayService : IPayService
{
    private readonly IPayRepository _payRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public PayService(IPayRepository payRepository, IUnitOfWork unitOfWork)
    {
        _payRepository = payRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Pay>> ListAsync()
    {
        return await _payRepository.ListAsync();
    }

    public async Task<PayResponse> CreateAsync(Pay pay)
    {
        try
        {
            await _payRepository.AddAsync(pay);
            await _unitOfWork.CompleteAsync();
      
            return new PayResponse(pay);
        }
        catch (Exception e)
        {
            return new PayResponse($"An error occurred while saving this payment: {e.Message}");
        }
    }

    public async Task<PayResponse> DeleteAsync(int id)
    {
        var existingPay = await _payRepository.FindByIdAsync(id);

        if (existingPay == null)
            return new PayResponse("Pay not found");

        try
        {
            _payRepository.Remove(existingPay);
            await _unitOfWork.CompleteAsync();

            return new PayResponse(existingPay);
        }
        catch (Exception e)
        {
            return new PayResponse($"An error occurred while deleting this pay: {e.Message}");
        }
    }
}