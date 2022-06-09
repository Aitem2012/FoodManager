using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodManager.Application.DTO.Users
{
    public class UpdateUserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public bool NewsletterSubscription { get; set; }
        public bool SmsNotification { get; set; }
        public bool EmailNotification { get; set; }
        public bool InAppNotification { get; set; }
    }
}
