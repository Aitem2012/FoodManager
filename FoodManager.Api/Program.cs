using FluentValidation.AspNetCore;
using FoodManager.Application.Mapping;
using FoodManager.Application.Validators;
using FoodManager.Persistence.Extensions;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.


builder.Services.AddDatabaseServices(config);
builder.Services.AddApplicationServices(config);
builder.Services.AddConfiguredService(config);
builder.Services.AddAuthenticationServices(config);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddMediatR(typeof(CreateUserDto).Assembly);
builder.Services.AddControllers()
    .AddFluentValidation(opt =>
    {
        opt.RegisterValidatorsFromAssembly(typeof(CreateUserDtoValidator).GetTypeInfo().Assembly);
    });

builder.Services.AddAutoMapper(typeof(FoodManagerMapping));
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Food ordering and management API",
        TermsOfService = new Uri("https://wwww.foodmanagement.com/terms-of-service"),
        License = new OpenApiLicense
        {
            Name = "FoodManagement License",
            Url = new Uri("https://www.foodmanagement.com/license")
        },
        Contact = new OpenApiContact
        {
            Email = "info@foodmanagement.com",
            Name = "FoodManagement Team",
            Url = new Uri("https://www.foodmanagement.com"),
        },
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Name = HeaderNames.Authorization,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFile));
});

//builder.Services.AddValidationService(config);
builder.Services.AddMediatorBehavior();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
