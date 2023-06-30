using JobSync.API.Payment.Domain.Models;
using JobSync.API.Payment.Domain.Repositories;
using JobSync.API.Shared.Persistence.Contexts;
using JobSync.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobSync.API.Payment.Persistence.Repositories;

public class PaymentPlanRepository : BaseRepository, IPaymentPlanRepository
{
    public PaymentPlanRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<PaymentPlan>> ListAsync()
    {
        return await Context.PaymentPlans.ToListAsync();
    }

    public async Task AddAsync(PaymentPlan plan)
    {
        await Context.PaymentPlans.AddAsync(plan);
    }

    public async Task<PaymentPlan> FindByIdAsync(int id)
    {
        return await Context.PaymentPlans.FindAsync(id);
    }

    public void Update(PaymentPlan plan)
    {
        Context.PaymentPlans.Update(plan);
    }

    public void Remove(PaymentPlan plan)
    {
        Context.PaymentPlans.Remove(plan);
    }
}