using FoodManager.Domain.Entity;
using FoodManager.Domain.Menus;

namespace FoodManager.Domain.Orders
{
    public class OrderItem : BaseEntity
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}
