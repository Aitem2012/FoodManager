using FoodManager.Domain.Entity;

namespace FoodManager.Domain.Users
{
    public class Address : BaseEntity
    {
        public string AppUserId { get; set; }
        public AppUser User { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
