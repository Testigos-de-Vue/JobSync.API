using JobSync.API.Payment.Domain.Models;
using JobSync.API.Payment.Domain.Repositories;
using JobSync.API.Shared.Persistence.Contexts;
using JobSync.API.Shared.Persistence.Repositories;

namespace JobSync.API.Payment.Persistence.Repositories;

public class PaymentPlanRepository : BaseRepository, IPaymentPlanRepository
{
    public PaymentPlanRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<PaymentPlan>> ListAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(PaymentPlan plan)
    {
        throw new NotImplementedException();
    }

    public async Task<PaymentPlan> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(PaymentPlan plan)
    {
        throw new NotImplementedException();
    }

    public void Remove(PaymentPlan plan)
    {
        throw new NotImplementedException();
    }
}