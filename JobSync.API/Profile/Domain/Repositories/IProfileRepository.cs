namespace JobSync.API.Profile.Domain.Repositories;

public interface IProfileRepository
{
  Task<IEnumerable<Models.Profile>> ListAsync();
  Task AddAsync(Models.Profile profile);
  Task<Models.Profile> FindByIdAsync(int id);
  void Update(Models.Profile profile);
  void Remove(Models.Profile profile);
}