using FoodManager.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodManager.Persistence.Orders.Configurations
{
    public class OrderEntityTypeConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User).WithMany(x => x.Orders);
            builder.Property(x => x.PaymentAmount).HasPrecision(8, 3);
        }
    }
}
