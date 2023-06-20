using JobSync.API.Payment.Domain.Models;

namespace JobSync.API.Payment.Domain.Repositories;

public interface IPaymentPlanRepository
{
    Task<IEnumerable<PaymentPlan>> ListAsync();
    Task AddAsync(PaymentPlan plan);
    Task<PaymentPlan> FindByIdAsync(int id);
    void Update(PaymentPlan plan);
    void Remove(PaymentPlan plan);
}