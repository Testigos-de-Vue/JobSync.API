using JobSync.API.Payment.Domain.Models;
using JobSync.API.Shared.Domain.Services.Communication;

namespace JobSync.API.Payment.Domain.Services.Communication;

public class PaymentPlanResponse : BaseResponse<PaymentPlan>
{
    public PaymentPlanResponse(string message) : base(message)
    {
    }

    public PaymentPlanResponse(PaymentPlan resource) : base(resource)
    {
    }
}