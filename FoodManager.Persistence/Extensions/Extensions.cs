using FoodManager.Application.Interfaces.Persistence;
using FoodManager.Persistence.Contexts;
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
        }
    }
}
