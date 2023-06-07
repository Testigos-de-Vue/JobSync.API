using JobSync.API.Profile.Domain.Models;
using JobSync.API.Profile.Domain.Repositories;
using JobSync.API.Shared.Persistence.Contexts;
using JobSync.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobSync.API.Profile.Persistence.Repositories;

public class RoleRepository : BaseRepository, IRoleRepository
{
  public RoleRepository(AppDbContext context) : base(context)
  {
  }

  public async Task<IEnumerable<Role>> ListAsync()
  {
    return await Context.Roles.ToListAsync();
  }

  public async Task AddAsync(Role role)
  {
    await Context.Roles.AddAsync(role);
  }

  public async Task<Role> FindByIdAsync(int id)
  {
    return await Context.Roles.FindAsync(id);
  }

  public async Task<Role> FindByNameAsync(string name)
  {
    return await Context.Roles.FindAsync(name);
  }

  public void Update(Role role)
  {
    Context.Roles.Update(role);
  }

  public void Remove(Role role)
  {
    Context.Roles.Remove(role);
  }
}