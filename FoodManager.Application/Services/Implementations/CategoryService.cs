using FoodManager.Application.DTO.Categories;
using FoodManager.Application.Interfaces.Abstracts;
using FoodManager.Application.Interfaces.Repositories;
using FoodManager.Common.Response;

namespace FoodManager.Application.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<BaseResponse<GetCategoryResponseObjectDto>> CreateCategoryAsync(CreateCategoryDto model)
        {
            return await _categoryRepository.CreateCategoryAsync(model, new CancellationToken());
        }

        public async Task<BaseResponse<bool>> DeleteCategoryAsync(Guid categoryId)
        {
            return await _categoryRepository.DeleteCategoryAsync(categoryId);
        }

        public async Task<BaseResponse<IEnumerable<GetCategoryResponseObjectDto>>> GetCategoriesAsync()
        {
            return await _categoryRepository.GetCategoriesAsync();
        }

        public async Task<BaseResponse<GetCategoryResponseObjectDto>> GetCategoryByIdAsync(Guid categoryId)
        {
            return await _categoryRepository.GetCategoryByIdAsync(categoryId);
        }

        public async Task<BaseResponse<GetCategoryResponseObjectDto>> UpdateCategoryAsync(UpdateCategoryDto model)
        {
            return await _categoryRepository.UpdateCategoryAsync(model, new CancellationToken());
        }
    }
}
