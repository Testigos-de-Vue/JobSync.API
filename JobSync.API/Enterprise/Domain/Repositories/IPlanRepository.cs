namespace JobSync.API.Organization.Domain.Repositories;
using JobSync.API.Organization.Domain.Models;


public interface IPlanRepository
{
    Task<IEnumerable<Plan>> ListAsync();
    Task AddAsync(Plan plan);
    Task<Plan> FindByIdAsync(int id);
    Task<Plan> FindByNameAsync(string name);
    void Update(Plan plan);
    void Remove(Plan plan);
}