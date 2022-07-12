using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnboardingAPI.Abstractions;
using OnboardingAPI.Abstractions.IMappingConfig;
using OnboardingAPI.Abstractions.IRepository;
using OnboardingAPI.Abstractions.IServices;
using OnboardingAPI.Implementations;
using OnboardingAPI.Implementations.MappingConfig;
using OnboardingAPI.Implementations.Repository;
using OnboardingAPI.Implementations.Services;
using OnboardingAPI.Models;
using OnboardingAPI.Models.AppDbContext;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApiDbConnection")));

builder.Services.AddControllers();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICustomersRepo, CustomersRepo>();
builder.Services.AddScoped<ILocalGovtsRepo, LocalGovtsRepo>();
builder.Services.AddScoped<IStatesRepo, StatesRepo>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomMapping, CustomMapping>();
builder.Services.AddScoped<IPasswordHasher<Customers>, PasswordHasher<Customers>>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
