using JobSync.API.Authentication.Domain.Models;
using JobSync.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace JobSync.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
  public DbSet<User> Users { get; set; }
  
  public AppDbContext(DbContextOptions options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);
    
    // Users Configuration

    builder.Entity<User>().ToTable("Users");
    builder.Entity<User>().HasKey(u => u.Id);
    builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
    builder.Entity<User>().Property(u => u.Name).IsRequired().HasMaxLength(32);
    builder.Entity<User>().Property(u => u.LastName).IsRequired().HasMaxLength(64);
    builder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(64);
    builder.Entity<User>().Property(u => u.ImageUrl).IsRequired().HasMaxLength(256);
    builder.Entity<User>().Property(u => u.Password).IsRequired();
    builder.Entity<User>().Property(u => u.IsSubscribedToNewsletter).IsRequired();
    builder.Entity<User>().Property(u => u.PhoneNumber).IsRequired();
    
    
    // Apply Snake Case Naming Convention
    builder.UseSnakeCaseNamingConvention();
  }
}
