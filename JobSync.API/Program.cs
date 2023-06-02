using JobSync.API.Activity.Domain.Repositories;
using JobSync.API.Activity.Domain.Services;
using JobSync.API.Activity.Persistence.Repositories;
using JobSync.API.Activity.Services;
using JobSync.API.Authentication.Domain.Repositories;
using JobSync.API.Authentication.Domain.Services;
using JobSync.API.Authentication.Persistence.Repositories;
using JobSync.API.Authentication.Services;
using JobSync.API.Shared.Domain.Repositories;
using JobSync.API.Shared.Persistence.Contexts;
using JobSync.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// Authentication Bounded Context Injection Configuration
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPasswordHashingService, PasswordHashingService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

// Activity Bounded Context Injection Configuration
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

// AutoMapper Configuration
builder.Services.AddAutoMapper(
  typeof(JobSync.API.Authentication.Mapping.ModelToResourceProfile),
  typeof(JobSync.API.Authentication.Mapping.ResourceToModelProfile)
);

builder.Services.AddAutoMapper(
  typeof(JobSync.API.Activity.Mapping.ModelToResourceProfile),
  typeof(JobSync.API.Activity.Mapping.ResourceToModelProfile)
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
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
