using FoodManager.Domain.Menus;
using FoodManager.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodManager.Persistence.Orders.Configurations
{
    public class OrderItemEntityTypeConfigurations : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Menus);
            builder.Property(x => x.Price).HasPrecision(8, 3);
        }
    }
}
