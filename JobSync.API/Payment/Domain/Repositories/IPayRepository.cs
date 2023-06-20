using JobSync.API.Payment.Domain.Models;

namespace JobSync.API.Payment.Domain.Repositories;

public interface IPayRepository
{
    Task<IEnumerable<Pay>> ListAsync();
    Task AddAsync(Pay pay);
    Task<Pay> FindByIdAsync(int id);
    void Update(Pay pay);
    void Remove(Pay pay);
}