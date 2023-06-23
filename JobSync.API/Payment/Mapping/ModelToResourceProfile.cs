using JobSync.API.Payment.Domain.Models;
using JobSync.API.Payment.Resources;

namespace JobSync.API.Payment.Mapping;

public class ModelToResourceProfile : AutoMapper.Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Transaction, TransactionResource>();
        CreateMap<PaymentPlan, PaymentPlanResource>();
    }
}