using FoodManager.Application.DTO.OrderItems;
using FoodManager.Domain.Enums;

namespace FoodManager.Application.DTO.Orders
{
    public class CreateOrderDto
    {
        public string AppUserId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        //public PaymentStatus PaymentStatus { get; set; }
        //public decimal PaymentAmount { get; set; }
        //public ConfirmationStatus ConfirmationStatus { get; set; }
        //public DeliveryStatus DeliveryStatus { get; set; }
        public List<CreateOrderItemDto> OrderItems { get; set; }
    }
}
