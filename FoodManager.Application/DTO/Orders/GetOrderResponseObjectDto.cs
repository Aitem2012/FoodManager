using FoodManager.Application.DTO.OrderItems;

namespace FoodManager.Application.DTO.Orders
{
    public class GetOrderResponseObjectDto
    {
        public Guid Id { get; set; }
        public string AppUserId { get; set; }
        public string TrackingNumber { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public decimal PaymentAmount { get; set; }
        public string ConfirmationStatus { get; set; }
        public string DeliveryStatus { get; set; }
        public ICollection<GetOrderItemResponseObjectDto> OrderItems { get; set; }
    }
}
