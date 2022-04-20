using FoodManager.Domain.Orders;
using Microsoft.AspNetCore.Identity;

namespace FoodManager.Domain.Users
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public string ReferralCode { get; set; }
        public string InviteCode { get; set; }
        public bool NewsletterSubscription { get; set; }
        public bool SmsNotification { get; set; }
        public bool EmailNotification { get; set; }
        public bool InAppNotification { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
