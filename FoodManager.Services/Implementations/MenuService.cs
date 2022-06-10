using FoodManager.Application.DTO.Menus;
using FoodManager.Application.Interfaces.Repositories;
using FoodManager.Common.Response;
using FoodManager.Services.Abstracts;
using Microsoft.Extensions.Logging;

namespace FoodManager.Services.Implementations
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly ILogger<MenuService> _logger;

        public MenuService(IMenuRepository menuRepository, ILogger<MenuService> logger)
        {
            _menuRepository = menuRepository;
            _logger = logger;
        }

        public async Task<BaseResponse<GetMenuResponseObjectDto>> CreateMenuAsync(CreateMenuDto menu)
        {
            return await _menuRepository.CreateMenuAsync(menu, new CancellationToken());
        }

        public async Task<BaseResponse<bool>> DeleteMenuAsync(Guid menuId)
        {
            return await _menuRepository.DeleteMenuAsync(menuId, new CancellationToken());
        }

        public async Task<BaseResponse<IEnumerable<GetMenuResponseObjectDto>>> GetAvailableMenuAsync()
        {
            return await _menuRepository.GetAvailableMenuAsync();
        }

        public async Task<BaseResponse<GetMenuResponseObjectDto>> GetMenuByIdAsync(Guid menuId)
        {
            return await _menuRepository.GetMenuByIdAsync(menuId);
        }

        public async Task<BaseResponse<IEnumerable<GetMenuResponseObjectDto>>> GetMenusAsync()
        {
            return await _menuRepository.GetMenusAsync();
        }

        public async Task<BaseResponse<GetMenuResponseObjectDto>> UpdateMenuAsync(UpdateMenuDto menu)
        {
            return await _menuRepository.UpdateMenuAsync(menu, new CancellationToken());
        }
    }
}
