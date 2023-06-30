using JobSync.API.Payment.Domain.Models;
using JobSync.API.Payment.Domain.Repositories;
using JobSync.API.Payment.Domain.Services;
using JobSync.API.Payment.Domain.Services.Communication;
using JobSync.API.Shared.Domain.Repositories;

namespace JobSync.API.Payment.Services;

public class PaymentPlanService : IPaymentPlanService
{
    private readonly IPaymentPlanRepository _planRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public PaymentPlanService(IPaymentPlanRepository planRepository, IUnitOfWork unitOfWork)
    {
        _planRepository = planRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<PaymentPlan>> ListAsync()
    {
        return await _planRepository.ListAsync();
    }

    public async Task<PaymentPlanResponse> CreateAsync(PaymentPlan plan)
    {
        try
        {
            await _planRepository.AddAsync(plan);
            await _unitOfWork.CompleteAsync();
      
            return new PaymentPlanResponse(plan);
        }
        catch (Exception e)
        {
            return new PaymentPlanResponse($"An error occurred while saving the payment plan: {e.Message}");
        }
    }

    public async Task<PaymentPlanResponse> UpdateAsync(int id, PaymentPlan plan)
    {
        var existingPlan = await _planRepository.FindByIdAsync(id);

        if (existingPlan == null)
            return new PaymentPlanResponse("Payment plan not found");

        existingPlan.name = plan.name;
        existingPlan.initialPrice = plan.initialPrice;
        existingPlan.interest = plan.interest;
        existingPlan.lapse = plan.lapse;

        try
        {
            _planRepository.Update(existingPlan);
            await _unitOfWork.CompleteAsync();

            return new PaymentPlanResponse(existingPlan);
        }
        catch (Exception e)
        {
            return new PaymentPlanResponse($"An error occurred while updating this plan: {e.Message}");
        }
    }

    public async Task<PaymentPlanResponse> DeleteAsync(int id)
    {
        var existingPlan = await _planRepository.FindByIdAsync(id);

        if (existingPlan == null)
            return new PaymentPlanResponse("Payment plan not found");

        try
        {
            _planRepository.Remove(existingPlan);
            await _unitOfWork.CompleteAsync();

            return new PaymentPlanResponse(existingPlan);
        }
        catch (Exception e)
        {
            return new PaymentPlanResponse($"An error occurred while deleting this payment plan: {e.Message}");
        }
    }
}