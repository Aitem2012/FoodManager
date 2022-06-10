using FoodManager.Application.Behaviors;
using FoodManager.Application.Implementations.Addresses;
using FoodManager.Application.Implementations.Users;
using FoodManager.Application.Interfaces.Persistence;
using FoodManager.Application.Interfaces.Repositories;
using FoodManager.Domain.Users;
using FoodManager.Persistence.Contexts;
using FoodManager.Services.Abstracts;
using FoodManager.Services.Implementations;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FoodManager.Persistence.Extensions
{
    public static class Extensions
    {
        public static void AddDatabaseServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<IAppDbContext, AppDbContext>();

            services.AddDbContext<AppDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentityCore<AppUser>();
            services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
        }

        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAppDbContext, AppDbContext>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRespository>();
            services.AddScoped<IAddressRepository, AddressRespository>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ISmsService, SmsService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
        }

        public static void AddAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("JWTConfigurations:SecretKey").Value)),
                    ValidateIssuer = true,
                    ValidIssuer = configuration.GetSection("JWTConfigurations:Issuer").Value,
                    ValidateAudience = true,
                    ValidAudience = configuration.GetSection("JWTConfigurations:Audience").Value
                };
            }).AddCookie(options =>
            {
                options.ForwardAuthenticate = CookieAuthenticationDefaults.AuthenticationScheme;
            });
        }

        public static void AddMediatorBehavior(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
