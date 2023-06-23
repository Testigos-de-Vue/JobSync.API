using JobSync.API.Payment.Domain.Models;
using JobSync.API.Shared.Domain.Services.Communication;

namespace JobSync.API.Payment.Domain.Services.Communication;

public class TransactionResponse : BaseResponse<Transaction>
{
    public TransactionResponse(string message) : base(message)
    {
    }

    public TransactionResponse(Transaction resource) : base(resource)
    {
    }
}