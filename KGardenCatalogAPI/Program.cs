using Application.Interfaces;
using Application.Services;
using Domain.Extensions;
using Infra.Data.Context;
using KGardenCatalogAPI.Filters;
using KGardenCatalogAPI.Logging;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");



builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString, b => b.MigrationsAssembly("KGardenCatalogAPI")));

//Logger
builder.Services.AddScoped<ApiLoggingFilter>();

//Application
builder.Services.AddScoped<IProductAppService, ProductAppService>();
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();

builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
{
    LogLevel = LogLevel.Information
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureExceptionHandler();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
