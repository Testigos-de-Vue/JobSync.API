using JobSync.API.Payment.Domain.Models;
using JobSync.API.Payment.Domain.Services.Communication;

namespace JobSync.API.Payment.Domain.Services;

public interface IPaymentPlanService
{
    Task<IEnumerable<PaymentPlan>> ListAsync();
    Task<PaymentPlanResponse> CreateAsync(PaymentPlan plan);
    Task<PaymentPlanResponse> UpdateAsync(int id, PaymentPlan plan);
    Task<PaymentPlanResponse> DeleteAsync(int id);
}