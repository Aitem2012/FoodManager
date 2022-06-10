using FoodManager.Domain.Enums;

namespace FoodManager.Application.DTO.Menus
{
    public class CreateMenuDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public decimal UnitPrice { get; set; }
        public string ImageUrl { get; set; }
        public Size Size { get; set; }
        public string Ingredients { get; set; }
        public string Instruction { get; set; }
    }
}
