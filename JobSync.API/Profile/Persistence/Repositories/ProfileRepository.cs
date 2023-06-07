using JobSync.API.Profile.Domain.Repositories;
using JobSync.API.Shared.Persistence.Contexts;
using JobSync.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobSync.API.Profile.Persistence.Repositories;

public class ProfileRepository : BaseRepository, IProfileRepository
{
  public ProfileRepository(AppDbContext context) : base(context)
  {
  }

  public async Task<IEnumerable<Domain.Models.Profile>> ListAsync()
  {
    return await Context.Profiles.ToListAsync();
  }

  public async Task AddAsync(Domain.Models.Profile profile)
  {
    await Context.Profiles.AddAsync(profile);
  }

  public async Task<Domain.Models.Profile> FindByIdAsync(int id)
  {
    return await Context.Profiles.FindAsync(id);
  }

  public void Update(Domain.Models.Profile profile)
  {
    Context.Profiles.Update(profile);
  }

  public void Remove(Domain.Models.Profile profile)
  {
    Context.Profiles.Remove(profile);
  }
}