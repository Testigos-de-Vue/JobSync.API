﻿using JobSync.API.Security.Domain.Models;

namespace JobSync.API.Security.Domain.Repositories;

public interface IUserRepository
{
  Task<IEnumerable<User>> ListAsync();
  Task AddAsync(User user);
  Task<User> FindByIdAsync(int id);
  Task<User> FindByEmailAsync(string email);
  void Update(User user);
  void Remove(User user);
}
