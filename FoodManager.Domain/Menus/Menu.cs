using FoodManager.Domain.Entity;
using FoodManager.Domain.Enums;

namespace FoodManager.Domain.Menus
{
    public class Menu : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public decimal UnitPrice { get; set; }
        public string ImageUrl { get; set; }
        public Size Size { get; set; }
        public string Ingredients { get; set; }
        public string Instruction { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
