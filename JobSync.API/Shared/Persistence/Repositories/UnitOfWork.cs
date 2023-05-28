using JobSync.API.Shared.Domain.Repositories;
using JobSync.API.Shared.Persistence.Contexts;

namespace JobSync.API.Shared.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
  private readonly AppDbContext _context;
  
  public UnitOfWork(AppDbContext context)
  {
    _context = context;
  }
  
  public async Task CompleteAsync()
  {
    await _context.SaveChangesAsync();
  }
}
