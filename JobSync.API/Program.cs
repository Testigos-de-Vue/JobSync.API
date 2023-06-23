using JobSync.API.Activity.Domain.Repositories;
using JobSync.API.Activity.Domain.Services;
using JobSync.API.Activity.Persistence.Repositories;
using JobSync.API.Activity.Services;
using JobSync.API.Security.Domain.Repositories;
using JobSync.API.Security.Domain.Services;
using JobSync.API.Security.Persistence.Repositories;
using JobSync.API.Security.Services;
using JobSync.API.Profile.Domain.Repositories;
using JobSync.API.Profile.Domain.Services;
using JobSync.API.Profile.Persistence.Repositories;
using JobSync.API.Profile.Services;
using JobSync.API.Recruitment.Domain.Repositories;
using JobSync.API.Recruitment.Domain.Services;
using JobSync.API.Recruitment.Persistence.Repositories;
using JobSync.API.Recruitment.Services;
using JobSync.API.Security.Authorization.Handlers.Implementations;
using JobSync.API.Security.Authorization.Handlers.Interfaces;
using JobSync.API.Shared.Domain.Repositories;
using JobSync.API.Shared.Persistence.Contexts;
using JobSync.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
  options.SwaggerDoc("v1", new OpenApiInfo
  {
    Version = "v1",
    Title = "JobSync API",
    Description = "JobSync Restful API",
    TermsOfService = new Uri("https://jobsync.netlify.app/terms-of-service/"),
    Contact = new OpenApiContact
    {
      Name = "Testigos de Vue",
      Url = new Uri("https://jobsync.netlify.app/"),
    },
    License = new OpenApiLicense
    {
      Name = "Testigos de Vue Resources License",
      Url = new Uri("https://jobsync.netlify.app/")
    }
  });
  options.EnableAnnotations();
});

builder.Services.AddCors(options =>
{
  options.AddDefaultPolicy(builder =>
  {
    builder.AllowAnyOrigin()
      .AllowAnyMethod()
      .AllowAnyHeader();
  });
});

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);

// Lower Case URLs Configuration
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Dependency Injection Configuration
// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Profile Bounded Context Injection Configuration
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();

// Authentication Bounded Context Injection Configuration
builder.Services.AddScoped<IJwtHandler, JwtHandler>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPasswordHashingService, PasswordHashingService>();

// Activity Bounded Context Injection Configuration
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

// Recruitment Bounded Context Injection Configuration
builder.Services.AddScoped<IPhaseService, PhaseService>();
builder.Services.AddScoped<IPhaseRepository, PhaseRepository>();
builder.Services.AddScoped<IProcessService, ProcessService>();
builder.Services.AddScoped<IProcessRepository, ProcessRepository>();


// AutoMapper Configuration
builder.Services.AddAutoMapper(
  typeof(JobSync.API.Security.Mapping.ModelToResourceProfile),
  typeof(JobSync.API.Security.Mapping.ResourceToModelProfile)
);
builder.Services.AddAutoMapper(
  typeof(JobSync.API.Profile.Mapping.ModelToResourceProfile),
  typeof(JobSync.API.Profile.Mapping.ResourceToModelProfile)
);
builder.Services.AddAutoMapper(
  typeof(JobSync.API.Activity.Mapping.ModelToResourceProfile),
  typeof(JobSync.API.Activity.Mapping.ResourceToModelProfile)
);
builder.Services.AddAutoMapper(
  typeof(JobSync.API.Recruitment.Mapping.ModelToResourceProfile),
  typeof(JobSync.API.Recruitment.Mapping.ResourceToModelProfile)
);

// Application Build
var app = builder.Build();

// Validation for ensuring Database Objects are created
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
  context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI(options =>
  {
    options.SwaggerEndpoint("v1/swagger.json", "v1");
    options.RoutePrefix = "swagger";
  });
}

app.UseCors(x => 
  x.SetIsOriginAllowed(origin => true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// Tests
public partial class Program {}