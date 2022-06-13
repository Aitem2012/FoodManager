using FoodManager.Application.DTO.Categories;
using FoodManager.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodManager.Api.Controllers
{
    /// <summary>
    /// This handles all requests for menus
    /// </summary>
    [Route("[controller]")]
    //[Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categorService;
        private readonly ILogger<CategoriesController> _logger;
        public CategoriesController(ICategoryService categorService, ILogger<CategoriesController> logger)
        {
            _categorService = categorService;
            _logger = logger;
        }
        /// <summary>
        /// Get all categories
        /// </summary>
        /// <param ></param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetCategories)), ProducesResponseType(typeof(IEnumerable<GetCategoryResponseObjectDto>), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _categorService.GetCategoriesAsync());
        }
        /// <summary>
        /// creates a new category
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost(Name = nameof(CreateCategory)), ProducesResponseType(typeof(GetCategoryResponseObjectDto), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> CreateCategory([FromForm] CreateCategoryDto model)
        {
            return Ok(await _categorService.CreateCategoryAsync(model));
        }

        /// <summary>
        /// Update a category
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("update-category", Name = nameof(UpdateCategory)), ProducesResponseType(typeof(GetCategoryResponseObjectDto), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDto model)
        {
            return Ok(await _categorService.UpdateCategoryAsync(model));
        }

        /// <summary>
        /// Get category by Id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet("{categoryId}", Name = nameof(GetCategoryById)), ProducesResponseType(typeof(GetCategoryResponseObjectDto), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> GetCategoryById([FromRoute] Guid categoryId)
        {
            return Ok(await _categorService.GetCategoryByIdAsync(categoryId));
        }

        /// <summary>
        /// delete menu by Id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpDelete("delete-menu/{menuId}", Name = nameof(DeleteCategory)), ProducesResponseType(typeof(bool), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid categoryId)
        {
            return Ok(await _categorService.DeleteCategoryAsync(categoryId));
        }
    }
}
