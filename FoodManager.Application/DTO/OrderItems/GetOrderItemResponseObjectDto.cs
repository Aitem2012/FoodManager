using FoodManager.Application.DTO.Menus;

namespace FoodManager.Application.DTO.OrderItems
{
    public class GetOrderItemResponseObjectDto
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
        public Guid MenuId { get; set; }
        public GetMenuResponseObjectDto Menu { get; set; }
    }
}
