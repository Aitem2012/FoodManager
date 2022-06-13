using FoodManager.Application.DTO.Categories;
using FoodManager.Common.Response;

namespace FoodManager.Services.Abstracts
{
    public interface ICategoryService
    {
        public Task<BaseResponse<GetCategoryResponseObjectDto>> CreateCategoryAsync(CreateCategoryDto model);
        public Task<BaseResponse<GetCategoryResponseObjectDto>> UpdateCategoryAsync(UpdateCategoryDto model);
        public Task<BaseResponse<bool>> DeleteCategoryAsync(Guid categoryId);
        public Task<BaseResponse<GetCategoryResponseObjectDto>> GetCategoryByIdAsync(Guid categoryId);
        public Task<BaseResponse<IEnumerable<GetCategoryResponseObjectDto>>> GetCategoriesAsync();
    }
}
