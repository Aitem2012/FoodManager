using System.ComponentModel;

namespace FoodManager.Domain.Enums
{
    public enum PaymentStatus
    {
        [Description("Pending")]
        Pending =1,
        [Description("Paid")]
        Paid,
        [Description("Cancelled")]
        Cancelled
    }

    public enum ConfirmationStatus
    {
        [Description("Confirmed")]
        Confirmed = 1,
        [Description("Pending Confirmation")]
        Pending
    }

    public enum DeliveryStatus
    {
        [Description("Delivered")]
        Delivered = 1,
        [Description("Pending Delivery")]
        Pending,
        [Description("Returned")]
        Returned
    }

    public enum Size
    {
        [Description("Small")]
        Small = 1,
        [Description("Medium")]
        Medium,
        [Description("large")]
        Large,
        [Description("Very Large")]
        VeryLarge
    }
}
