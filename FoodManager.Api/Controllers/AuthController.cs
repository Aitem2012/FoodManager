using FoodManager.Application.DTO.Users;
using FoodManager.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodManager.Api.Controllers
{
    /// <summary>
    /// This handles all requests for users
    /// </summary>
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        public AuthController(ILogger<AuthController> logger, IUserService userService, IAuthService authService)
        {
            _logger = logger;
            _userService = userService;
            _authService = authService;
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("signup", Name = nameof(Signup)), ProducesResponseType(typeof(GetUserResponseObjectDto), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> Signup([FromBody] CreateUserDto model)
        {
            return Ok(await _userService.CreateUser(model, new CancellationToken()));
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("login", Name = nameof(Login)), ProducesResponseType(typeof(UserLoginResponseDto), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> Login([FromForm] UserLoginDto model)
        {
            return Ok(await _authService.Login(model));
        }

        /// <summary>
        /// Forgot password
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("forgotpassword/{email}", Name = nameof(ForgotPassword)), ProducesResponseType(typeof(string), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> ForgotPassword([FromRoute] string email)
        {
            return Ok(await _authService.ForgotPassword(email));
        }

        /// <summary>
        /// Forgot password
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("resetpassword", Name = nameof(ResetPassword)), ProducesResponseType(typeof(bool), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> ResetPassword([FromBody] ResetUserPasswordDto model)
        {
            return Ok(await _authService.ResetPassword(model));
        }

        /// <summary>
        /// SignOut
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("signout/{email}", Name = nameof(Logout)), ProducesResponseType(typeof(bool), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> Logout(string email)
        {
            //TODO: Properly implement signout
            return Ok(await _authService.SignOut(email));
        }
    }
}
