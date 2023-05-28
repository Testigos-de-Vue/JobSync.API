using JobSync.API.Shared.Persistence.Contexts;

namespace JobSync.API.Shared.Persistence.Repositories;

public class BaseRepository
{
  protected readonly AppDbContext Context;

  public BaseRepository(AppDbContext context)
  {
    Context = context;
  }
}
