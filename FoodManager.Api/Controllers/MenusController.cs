using FoodManager.Application.DTO.Menus;
using FoodManager.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodManager.Api.Controllers
{
    /// <summary>
    /// This handles all requests for menus
    /// </summary>
    [Route("[controller]")]
    [Authorize]
    public class MenusController : ControllerBase
    {
        private readonly ILogger<MenusController> _logger;
        private readonly IMenuService _menuService;
        public MenusController(ILogger<MenusController> logger, IMenuService menuService)
        {
            _logger = logger;
            _menuService = menuService;
        }

        /// <summary>
        /// Get all menus
        /// </summary>
        /// <param ></param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetMenus)), ProducesResponseType(typeof(IEnumerable<GetMenuResponseObjectDto>), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> GetMenus()
        {
            return Ok(await _menuService.GetMenusAsync());
        }

        /// <summary>
        /// Get all available menus
        /// </summary>
        /// <param ></param>
        /// <returns></returns>
        [HttpGet("get-available-menu",Name = nameof(GetAvailableMenus)), ProducesResponseType(typeof(IEnumerable<GetMenuResponseObjectDto>), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> GetAvailableMenus()
        {
            return Ok(await _menuService.GetMenusAsync());
        }

        /// <summary>
        /// creates a new menu
        /// </summary>
        /// <param name="model"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost(Name = nameof(CreateMenu)), ProducesResponseType(typeof(GetMenuResponseObjectDto), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> CreateMenu([FromForm] CreateMenuDto model, IFormFile file)
        {
            return Ok(await _menuService.CreateMenuAsync(model, file));
        }

        /// <summary>
        /// Update a menu
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("update-menu", Name = nameof(UpdateMenu)), ProducesResponseType(typeof(GetMenuResponseObjectDto), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateMenu([FromBody] UpdateMenuDto model)
        {
            return Ok(await _menuService.UpdateMenuAsync(model));
        }

        /// <summary>
        /// Update a menu
        /// </summary>
        /// <param name="file"></param>
        /// <param name="menuId"></param>
        /// <returns></returns>
        [HttpPut("update-menu-image", Name = nameof(UpdateMenuImage)), ProducesResponseType(typeof(GetMenuResponseObjectDto), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateMenuImage(IFormFile file, Guid menuId)
        {
            return Ok(await _menuService.UpdateMenuImage(file, menuId));
        }

        /// <summary>
        /// Get menu by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = nameof(GetMenuById)), ProducesResponseType(typeof(GetMenuResponseObjectDto), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> GetMenuById([FromRoute] Guid id)
        {
            return Ok(await _menuService.GetMenuByIdAsync(id));
        }

        /// <summary>
        /// delete menu by Id
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        [HttpDelete("delete-menu/{menuId}", Name = nameof(DeleteMenu)), ProducesResponseType(typeof(GetMenuResponseObjectDto), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteMenu([FromRoute] Guid menuId)
        {
            return Ok(await _menuService.DeleteMenuAsync(menuId));
        }


    }
}
