namespace FoodManager.Application.DTO.OrderItems
{
    public class CreateOrderItemDto
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
        public Guid MenuId { get; set; }
    }
}
