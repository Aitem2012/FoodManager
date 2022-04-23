using FoodManager.Application.DTO.Users;
using FoodManager.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace FoodManager.Api.Controllers
{
    /// <summary>
    /// This handles all requests for users
    /// </summary>
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        /// <summary>
        /// creates a new Comment
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateComment"), ProducesResponseType(typeof(GetUserResponseObject), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> CreateComment([FromBody] CreateUserDto model)
        {
            
            return Ok(await _userService.CreateUser(model, new CancellationToken()));
        }
    }
}
