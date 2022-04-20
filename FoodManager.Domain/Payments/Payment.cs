using FoodManager.Domain.Entity;

namespace FoodManager.Domain.Payments
{
    public class Payment : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
