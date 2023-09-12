using Microsoft.EntityFrameworkCore;
using ToDoApp.Infrastructure.Persistence;
using ToDoApp.Core.Repositories;
using ToDoApp.Infrastructure.Persistence.Repositories;
using ToDoApp.Core.Services.AuthService;
using ToDoApp.Infrastructure.Services.AuthService;
using ToDoApp.Core.Services.EmailService;
using ToDoApp.Infrastructure.Services.EmailService;
using ToDoApp.Application.Queries.Task.GetAllTasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("AppCs");
builder.Services.AddDbContext<ToDoAppContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllTasksQuery).Assembly));

var app = builder.Build();

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
