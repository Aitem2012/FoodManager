using FoodManager.Domain.Entity;
using FoodManager.Domain.Enums;
using FoodManager.Domain.Users;

namespace FoodManager.Domain.Orders
{
    public class Order : BaseEntity
    {
        public string AppUserId { get; set; }
        public AppUser User { get; set; }
        public string TrackingNumber { get; set; }
        public string PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public decimal PaymentAmount { get; set; }
        public ConfirmationStatus ConfirmationStatus { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }

    }
}
