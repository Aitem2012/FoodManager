using FoodManager.Application.DTO.Categories;
using FoodManager.Common.Response;

namespace FoodManager.Application.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        public Task<BaseResponse<GetCategoryResponseObjectDto>> CreateCategoryAsync(CreateCategoryDto model, CancellationToken cancellationToken);
        public Task<BaseResponse<GetCategoryResponseObjectDto>> UpdateCategoryAsync(UpdateCategoryDto model, CancellationToken cancellationToken);
        public Task<BaseResponse<bool>> DeleteCategoryAsync(Guid menuId);
    }
}
