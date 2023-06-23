using JobSync.API.Security.Domain.Models;
using JobSync.API.Security.Domain.Repositories;
using JobSync.API.Shared.Persistence.Contexts;
using JobSync.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JobSync.API.Security.Persistence.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
  public UserRepository(AppDbContext context) : base(context)
  {
  }


  public async Task<IEnumerable<User>> ListAsync()
  {
    return await Context.Users.ToListAsync();
  }

  public async Task AddAsync(User user)
  {
    await Context.Users.AddAsync(user);
  }

  public async Task<User> FindByIdAsync(int id)
  {
    return await Context.Users.FindAsync(id);
  }

  public async Task<User> FindByEmailAsync(string email)
  {
    return await Context.Users.SingleOrDefaultAsync(user => user.Email == email);
  }

  public bool ExistsByEmail(string email)
  {
    return Context.Users.Any(user => user.Email == email);
  }

  public User FindById(int id)
  {
    return Context.Users.Find(id);
  }

  public void Update(User user)
  {
    Context.Users.Update(user);
  }

  public void Remove(User user)
  {
    Context.Users.Remove(user);
  }
}
