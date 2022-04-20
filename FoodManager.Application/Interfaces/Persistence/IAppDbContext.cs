using FoodManager.Domain.Menus;
using FoodManager.Domain.Orders;
using FoodManager.Domain.Payments;
using FoodManager.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace FoodManager.Application.Interfaces.Persistence
{
    public interface IAppDbContext
    {
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Payment> Payments { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
