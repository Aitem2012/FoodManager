﻿using FoodManager.Application.DTO.Users;
using FoodManager.Application.Interfaces.Abstracts;
using Microsoft.AspNetCore.Mvc;

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
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("signup", Name = nameof(Signup)), ProducesResponseType(typeof(GetUserResponseObjectDto), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> Signup([FromForm] CreateUserDto model, IFormFile file)
        {
            return Ok(await _userService.CreateUser(model, new CancellationToken(), "user", file));
        }

        /// <summary>
        /// Register a new admin user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("signup-admin", Name = nameof(SignupAdmin)), ProducesResponseType(typeof(GetUserResponseObjectDto), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> SignupAdmin([FromForm] CreateUserDto model, IFormFile file)
        {
            return Ok(await _userService.CreateUser(model, new CancellationToken(), "admin", file));
        }

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("login", Name = nameof(Login)), ProducesResponseType(typeof(UserLoginResponseDto), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> Login([FromForm] UserLoginDto model)
        {
            return Ok(await _authService.Login(model));
        }

        /// <summary>
        /// Forgot password
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("forgotpassword/{email}", Name = nameof(ForgotPassword)), ProducesResponseType(typeof(string), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> ForgotPassword([FromRoute] string email)
        {
            return Ok(await _authService.ForgotPassword(email));
        }

        /// <summary>
        /// Forgot password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("resetpassword", Name = nameof(ResetPassword)), ProducesResponseType(typeof(bool), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> ResetPassword([FromBody] ResetUserPasswordDto model)
        {
            return Ok(await _authService.ResetPassword(model));
        }

        /// <summary>
        /// SignOut
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("signout/{email}", Name = nameof(Logout)), ProducesResponseType(typeof(bool), StatusCodes.Status201Created), ProducesDefaultResponseType]
        public async Task<IActionResult> Logout(string email)
        {
            //TODO: Properly implement signout
            return Ok(await _authService.SignOut(email));
        }
    }
}
