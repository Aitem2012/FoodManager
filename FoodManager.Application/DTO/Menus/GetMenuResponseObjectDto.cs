using FoodManager.Domain.Enums;

namespace FoodManager.Application.DTO.Menus
{
    public class GetMenuResponseObjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public decimal UnitPrice { get; set; }
        public string ImageUrl { get; set; }
        public string Size { get; set; }
        public string Ingredients { get; set; }
        public string Instruction { get; set; }
    }
}
