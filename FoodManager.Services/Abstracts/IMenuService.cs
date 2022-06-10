using FoodManager.Application.DTO.Menus;
using FoodManager.Common.Response;

namespace FoodManager.Services.Abstracts
{
    public interface IMenuService
    {
        public Task<BaseResponse<GetMenuResponseObjectDto>> CreateMenuAsync(CreateMenuDto menu);
        public Task<BaseResponse<GetMenuResponseObjectDto>> UpdateMenuAsync(UpdateMenuDto menu);
        public Task<BaseResponse<bool>> DeleteMenuAsync(Guid menuId);
        public Task<BaseResponse<GetMenuResponseObjectDto>> GetMenuByIdAsync(Guid menuId);
        public Task<BaseResponse<IEnumerable<GetMenuResponseObjectDto>>> GetAvailableMenuAsync();
        public Task<BaseResponse<IEnumerable<GetMenuResponseObjectDto>>> GetMenusAsync();
    }
}
