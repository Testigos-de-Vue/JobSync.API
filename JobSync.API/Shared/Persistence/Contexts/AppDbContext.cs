using JobSync.API.Activity.Domain.Models;
using JobSync.API.Authentication.Domain.Models;
using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace JobSync.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
  public DbSet<User> Users { get; set; }
  public DbSet<TaskItem> TaskItems {get; set;}
  public DbSet<JobArea> JobAreas { get; set; }
  public DbSet<CandidateProfile> CandidateProfiles { get; set; }
  public DbSet<Phase> Phases { get; set; }
  public DbSet<Process> Processes { get; set; }

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
    
    // TaskItems Configuration
    builder.Entity<TaskItem>().Property(t=>t.Id).IsRequired().ValueGeneratedOnAdd();
    builder.Entity<TaskItem>().Property(t=>t.Description).IsRequired().HasMaxLength(64);
    builder.Entity<TaskItem>().Property(t=>t.Date).IsRequired();
    
    // JobAreas Configuration
    builder.Entity<JobArea>().ToTable("JobAreas");
    builder.Entity<JobArea>().HasKey(j=>j.Id);
    builder.Entity<JobArea>().Property(j=>j.Id).IsRequired().ValueGeneratedOnAdd();
    builder.Entity<JobArea>().Property(j=>j.Name).IsRequired().HasMaxLength(64);
    
    // CandidateProfiles Configuration
    builder.Entity<CandidateProfile>().ToTable("CandidateProfiles");
    builder.Entity<CandidateProfile>().HasKey(c=>c.Id);
    builder.Entity<CandidateProfile>().Property(c=>c.Id).IsRequired().ValueGeneratedOnAdd();
    builder.Entity<CandidateProfile>().Property(c => c.CvUrl).IsRequired().HasMaxLength(256);
    builder.Entity<CandidateProfile>().Property(c => c.IsActive).IsRequired();
    builder.Entity<CandidateProfile>().Property(c => c.PostulationDate).IsRequired();
    
    // Phases Configuration
    builder.Entity<Phase>().ToTable("Phases");
    builder.Entity<Phase>().HasKey(p=>p.Id);
    builder.Entity<Phase>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
    builder.Entity<Phase>().Property(p=>p.Name).IsRequired().HasMaxLength(64);
    builder.Entity<Phase>().Property(p=>p.Description).IsRequired().HasMaxLength(256);
    builder.Entity<Phase>().Property(p=>p.CreatedDate).IsRequired();
    
    // Processes Configuration
    builder.Entity<Process>().ToTable("Processes");
    builder.Entity<Process>().HasKey(p=>p.Id);
    builder.Entity<Process>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
    builder.Entity<Process>().Property(p=>p.Name).IsRequired().HasMaxLength(64);
    builder.Entity<Process>().Property(p=>p.Description).IsRequired().HasMaxLength(256);
    builder.Entity<Process>().Property(p=>p.StartingDate).IsRequired();
    builder.Entity<Process>().Property(p=>p.EndingDate).IsRequired();
    builder.Entity<Process>().Property(p=>p.Status).IsRequired();
    
    // Relationships
    builder.Entity<User>()
      .HasMany(u => u.CandidateProfiles)
      .WithOne(u => u.User)
      .HasForeignKey(u => u.UserId);
    builder.Entity<CandidateProfile>()
      .HasOne(c => c.JobArea)
      .WithMany(c => c.Candidates)
      .HasForeignKey(c => c.JobAreaId);
    builder.Entity<Phase>()
      .HasMany(p => p.CandidateProfiles)
      .WithOne(p => p.Phase)
      .HasForeignKey(p => p.PhaseId);
    builder.Entity<Process>()
      .HasMany(p => p.Phases)
      .WithOne(p => p.Process)
      .HasForeignKey(p => p.ProcessId);

    // Apply Snake Case Naming Convention
    builder.UseSnakeCaseNamingConvention();
  }
}
