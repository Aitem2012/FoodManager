using FoodManager.Application.DTO.Menus;
using FoodManager.Common.Response;
using FoodManager.Domain.Menus;

namespace FoodManager.Application.Interfaces.Repositories
{
    public interface IMenuRepository
    {
        public Task<BaseResponse<GetMenuResponseObjectDto>> CreateMenuAsync(CreateMenuDto menu, CancellationToken cancellationToken);
        public Task<BaseResponse<GetMenuResponseObjectDto>> UpdateMenuAsync(UpdateMenuDto menu, CancellationToken cancellationToken);
        public Task<BaseResponse<bool>> DeleteMenuAsync(Guid menuId, CancellationToken cancellationToken);
        public Task<BaseResponse<GetMenuResponseObjectDto>> GetMenuByIdAsync(Guid menuId);
        public Task<BaseResponse<IEnumerable<GetMenuResponseObjectDto>>> GetAvailableMenuAsync();
        public Task<BaseResponse<IEnumerable<GetMenuResponseObjectDto>>> GetMenusAsync();
    }
}
