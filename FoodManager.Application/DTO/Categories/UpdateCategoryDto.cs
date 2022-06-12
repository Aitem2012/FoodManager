namespace FoodManager.Application.DTO.Categories
{
    public class UpdateCategoryDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
    }
}
