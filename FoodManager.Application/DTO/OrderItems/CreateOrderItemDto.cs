namespace FoodManager.Application.DTO.OrderItems
{
    public class CreateOrderItemDto
    {
        public int Quantity { get; set; }
        public Guid MenuId { get; set; }
    }
}
