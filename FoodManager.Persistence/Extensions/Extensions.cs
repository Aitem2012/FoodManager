using FoodManager.Application.Implementations.Addresses;
using FoodManager.Application.Implementations.Users;
using FoodManager.Application.Interfaces.Persistence;
using FoodManager.Application.Interfaces.Repositories;
using FoodManager.Domain.Users;
using FoodManager.Persistence.Contexts;
using FoodManager.Services.Abstracts;
using FoodManager.Services.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
        }
    }
}
