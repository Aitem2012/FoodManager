using FoodManager.Application.DTO.FileUpload;
using FoodManager.Application.DTO.Menus;
using FoodManager.Application.Interfaces.Repositories;
using FoodManager.Common.Response;
using FoodManager.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FoodManager.Services.Implementations
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly ILogger<MenuService> _logger;
        private readonly IFileUploadService _uploadService;

        public MenuService(IMenuRepository menuRepository, ILogger<MenuService> logger, IFileUploadService uploadService)
        {
            _menuRepository = menuRepository;
            _logger = logger;
            _uploadService = uploadService;
        }

        public async Task<BaseResponse<GetMenuResponseObjectDto>> CreateMenuAsync(CreateMenuDto menu, IFormFile file)
        {
            var imageUrl = UploadMenuImage(file);
            return await _menuRepository.CreateMenuAsync(menu, imageUrl.Data.AvatarUrl, new CancellationToken());
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

        public async Task<BaseResponse<GetMenuResponseObjectDto>> UpdateMenuImage(IFormFile file, Guid menuId)
        {
            var menu = await _menuRepository.GetMenuByIdAsync(menuId);
            if (!menu.Status)
            {
                return menu;
            }
            var menuImageUrl = UploadMenuImage(file);
            return await _menuRepository.UpdateMenuImageAsync(menuId, menuImageUrl.Data.AvatarUrl, new CancellationToken());
        }

        private BaseResponse<UploadImageResponseDto> UploadMenuImage(IFormFile file)
        {
            return new BaseResponse<UploadImageResponseDto>().CreateResponse("", true, _uploadService.UploadAvatar(file));
        }
    }
}
