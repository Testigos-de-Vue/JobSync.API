using JobSync.API.Payment.Domain.Models;
using JobSync.API.Payment.Domain.Services.Communication;

namespace JobSync.API.Payment.Domain.Services;

public interface IPayService
{
    Task<IEnumerable<Pay>> ListAsync();
    Task<PayResponse> CreateAsync(Pay pay);
    Task<PayResponse> DeleteAsync(int id);
}