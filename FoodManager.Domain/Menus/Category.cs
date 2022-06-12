using FoodManager.Domain.Entity;

namespace FoodManager.Domain.Menus
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public ICollection<Menu> Menus { get; set; }

    }
}
