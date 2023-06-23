using JobSync.API.Activity.Domain.Models;
using JobSync.API.Authentication.Domain.Models;
using JobSync.API.Organization.Domain.Models;
using JobSync.API.Payment.Domain.Models;
using JobSync.API.Profile.Domain.Models;
using JobSync.API.Recruitment.Domain.Models;
using JobSync.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace JobSync.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
  public DbSet<User> Users { get; set; }
  public DbSet<Role> Roles { get; set; }
  public DbSet<JobSync.API.Profile.Domain.Models.Profile> Profiles { get; set; }
  public DbSet<TaskItem> TaskItems {get; set;}
  public DbSet<Phase> Phases { get; set; }
  public DbSet<Process> Processes { get; set; }
  
  public DbSet<Plan> Plans { get; set; }
  
  public DbSet<Transaction> Transactions { get; set; }

  public DbSet<PaymentPlan> PaymentPlans { get; set; }
  public DbSet<JobSync.API.Organization.Domain.Models.Organization> Organizations { get; set; }

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
    
    // Roles Configuration
    builder.Entity<Role>().ToTable("Roles");
    builder.Entity<Role>().HasKey(r => r.Id);
    builder.Entity<Role>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
    builder.Entity<Role>().Property(r => r.Name).IsRequired().HasMaxLength(24);
    
    // Profiles Configuration
    builder.Entity<JobSync.API.Profile.Domain.Models.Profile>().ToTable("Profiles");
    builder.Entity<JobSync.API.Profile.Domain.Models.Profile>().HasKey(p => p.Id);
    builder.Entity<JobSync.API.Profile.Domain.Models.Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
    builder.Entity<JobSync.API.Profile.Domain.Models.Profile>().Property(p => p.UserId).IsRequired();
    builder.Entity<JobSync.API.Profile.Domain.Models.Profile>().Property(p => p.CvUrl).HasMaxLength(255);
    builder.Entity<JobSync.API.Profile.Domain.Models.Profile>().Property(p => p.OrganizationId);
    
    // TaskItems Configuration
    builder.Entity<TaskItem>().ToTable("TaskItems");
    builder.Entity<TaskItem>().Property(t=>t.Id).IsRequired().ValueGeneratedOnAdd();
    builder.Entity<TaskItem>().Property(t=>t.Title).IsRequired().HasMaxLength(64);
    builder.Entity<TaskItem>().Property(t=>t.Description).IsRequired().HasMaxLength(256);
    builder.Entity<TaskItem>().Property(t=>t.Date).IsRequired();
    builder.Entity<TaskItem>().Property(t=>t.Status).IsRequired();

    // RecruitmentPhases Configuration
    builder.Entity<Phase>().ToTable("Phases");
    builder.Entity<Phase>().HasKey(p=>p.Id);
    builder.Entity<Phase>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
    builder.Entity<Phase>().Property(p=>p.Name).IsRequired().HasMaxLength(64);
    builder.Entity<Phase>().Property(p=>p.Description).IsRequired().HasMaxLength(256);
    builder.Entity<Phase>().Property(p=>p.CreatedDate).IsRequired();
    
    // RecruitmentProcesses Configuration
    builder.Entity<Process>().ToTable("Processes");
    builder.Entity<Process>().HasKey(p=>p.Id);
    builder.Entity<Process>().Property(p=>p.Id).IsRequired().ValueGeneratedOnAdd();
    builder.Entity<Process>().Property(p=>p.Name).IsRequired().HasMaxLength(64);
    builder.Entity<Process>().Property(p=>p.Description).IsRequired().HasMaxLength(256);
    builder.Entity<Process>().Property(p=>p.StartingDate).IsRequired();
    builder.Entity<Process>().Property(p=>p.EndingDate).IsRequired();
    builder.Entity<Process>().Property(p=>p.Status).IsRequired();
    
    // Organizations Configuration
    builder.Entity<Organization.Domain.Models.Organization>().ToTable("Organizations");
    builder.Entity<Organization.Domain.Models.Organization>().HasKey(o=>o.Id);
    builder.Entity<Organization.Domain.Models.Organization>().Property(o=>o.Id).IsRequired().ValueGeneratedOnAdd();
    builder.Entity<Organization.Domain.Models.Organization>().Property(o=>o.Name).IsRequired().HasMaxLength(256);
    builder.Entity<Organization.Domain.Models.Organization>().Property(o=>o.Email).IsRequired().HasMaxLength(64);
    builder.Entity<Organization.Domain.Models.Organization>().Property(o=>o.PhoneNumber).IsRequired().HasMaxLength(16);
    builder.Entity<Organization.Domain.Models.Organization>().Property(o=>o.LogoUrl).IsRequired().HasMaxLength(64);
    builder.Entity<Organization.Domain.Models.Organization>().Property(o=>o.Address).IsRequired().HasMaxLength(256);

    //Plans Configuration
    builder.Entity<Plan>().ToTable("Plans");
    builder.Entity<Plan>().HasKey(pl=>pl.Id);
    builder.Entity<Plan>().Property(pl=>pl.Id).IsRequired().ValueGeneratedOnAdd();
    builder.Entity<Plan>().Property(pl=>pl.Name).IsRequired().HasMaxLength(64);
    
    //Pays Configutation
    builder.Entity<Transaction>().ToTable("Transactions");
    builder.Entity<Transaction>().HasKey(p => p.id);
    builder.Entity<Transaction>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
    builder.Entity<Transaction>().Property(p => p.mount).IsRequired();
    builder.Entity<Transaction>().Property(p => p.currency).IsRequired().HasMaxLength(12);
    
    //Payment Plans Configuration
    builder.Entity<PaymentPlan>().ToTable("PaymentPlans");
    builder.Entity<PaymentPlan>().HasKey(p => p.id);
    builder.Entity<PaymentPlan>().Property(p=>p.id).IsRequired().ValueGeneratedOnAdd();
    builder.Entity<PaymentPlan>().Property(p => p.name).IsRequired().HasMaxLength(30);
    builder.Entity<PaymentPlan>().Property(p => p.initialPrice).IsRequired();
    builder.Entity<PaymentPlan>().Property(p => p.interest).IsRequired();
    builder.Entity<PaymentPlan>().Property(p => p.lapse).IsRequired();
    
    // Relationships
    builder.Entity<JobSync.API.Profile.Domain.Models.Profile>()
      .HasOne(p => p.Role)
      .WithMany(r => r.Profiles)
      .HasForeignKey(p => p.Id);

    builder.Entity<Role>()
      .HasMany(r => r.Profiles)
      .WithOne(p => p.Role)
      .HasForeignKey(p => p.Id);

    builder.Entity<Process>()
      .HasMany(p => p.Phases)
      .WithOne(p => p.Process)
      .HasForeignKey(p => p.RecruitmentProcessId);

    builder.Entity<Organization.Domain.Models.Organization>()
      .HasOne(o => o.OrganizationPlan)
      .WithMany(p => p.Organizations)
      .HasForeignKey(o => o.OrganizationPlanId);
    
    // Apply Snake Case Naming Convention
    builder.UseSnakeCaseNamingConvention();
  }
}
