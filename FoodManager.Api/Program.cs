using FoodManager.Application.DTO.JWT;
using FoodManager.Application.Mapping;
using FoodManager.Persistence.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var config =builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(FoodManagerMapping));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo
{
    Version = "v1",
    Title = "Food ordering and management API"
}));

builder.Services.AddDatabaseServices(config);
builder.Services.AddApplicationServices(config);
builder.Services.Configure<JWTData>(config.GetSection(JWTData.Data));

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
