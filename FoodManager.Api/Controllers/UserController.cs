using FoodManager.Application.DTO.Users;
using FoodManager.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodManager.Api.Controllers
{
    /// <summary>
    /// This handles all requests for users
    /// </summary>
    [Route("[controller]")]
    [Authorize]
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
        /// Get all users
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetUsers)), ProducesResponseType(typeof(GetUserResponseObjectDto), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _userService.GetUsers());
        }

        /// <summary>
        /// creates a new user
        /// </summary>
        /// <param name="model"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost(Name = nameof(CreateUser)), ProducesResponseType(typeof(GetUserResponseObjectDto), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> CreateUser([FromForm] CreateUserDto model, IFormFile file)
        {
            return Ok(await _userService.CreateUser(model, new CancellationToken(), "user", file));
        }

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("updateuser",Name = nameof(UpdateUser)), ProducesResponseType(typeof(GetUserResponseObjectDto), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto model)
        {
            return Ok(await _userService.UpdateUser(model, new CancellationToken()));
        }

        /// <summary>
        /// Get user by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = nameof(GetUserById)), ProducesResponseType(typeof(GetUserResponseObjectDto), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            return Ok(await _userService.GetUserById(id));
        }

        /// <summary>
        /// Get user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("/{email}", Name = nameof(GetUserByEmail)), ProducesResponseType(typeof(GetUserResponseObjectDto), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> GetUserByEmail([FromRoute] string email)
        {
            return Ok(await _userService.GetUserByEmail(email));
        }


    }
}
