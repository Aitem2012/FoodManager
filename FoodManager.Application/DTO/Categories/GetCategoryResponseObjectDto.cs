namespace FoodManager.Application.DTO.Categories
{
    public class GetCategoryResponseObjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int Menus { get; set; }
    }
}
