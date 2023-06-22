using JobSync.API.Payment.Domain.Models;
using JobSync.API.Shared.Domain.Services.Communication;

namespace JobSync.API.Payment.Domain.Services.Communication;

public class PayResponse : BaseResponse<Pay>
{
    public PayResponse(string message) : base(message)
    {
    }

    public PayResponse(Pay resource) : base(resource)
    {
    }
}