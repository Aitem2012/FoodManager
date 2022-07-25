using AutoMapper;
using FoodManager.Application.DTO.JWT;
using FoodManager.Application.DTO.Users;
using FoodManager.Common.Response;
using FoodManager.Domain.Users;
using FoodManager.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FoodManager.Services.Implementations
{
    public class AuthService1 : IAuthService
    {
        private readonly ILogger<AuthService1> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IOptions<JWTData> _JwtData;
        private readonly IMapper _mapper;

        public AuthService1(ILogger<AuthService1> logger, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, ITokenService tokenService, IOptions<JWTData> jwtData, IMapper mapper)
        {
            _logger = logger;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userManager = userManager;
            _tokenService = tokenService;
            _JwtData = jwtData;
            _mapper = mapper;
        }

        public async Task<BaseResponse<string>> ForgotPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return new BaseResponse<string>().CreateResponse($"No user with email: {email}", false, "");
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            return new BaseResponse<string>().CreateResponse("", true, token);
        }

        public async Task<BaseResponse<UserLoginResponseDto>> Login(UserLoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new BaseResponse<UserLoginResponseDto>().CreateResponse($"No user with email {model.Email}", false, null);
            }
            var checkPassword = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (!checkPassword.Succeeded)
            {
                return new BaseResponse<UserLoginResponseDto>().CreateResponse("Password is invalid", false, null);
            }
            var userRoles = await _userManager.GetRolesAsync(user) as List<string>;
            var token = _tokenService.GenerateToken(user, userRoles, _JwtData);
            var userToReturn = _mapper.Map<UserLoginResponseDto>(user);
            userToReturn.Token = token;
            return new BaseResponse<UserLoginResponseDto>().CreateResponse("", true, userToReturn);
        }

        public async Task<BaseResponse<bool>> ResetPassword(ResetUserPasswordDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new BaseResponse<bool>().CreateResponse($"No user with Email: {model.Email}", false, false);
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (!result.Succeeded)
            {
                return new BaseResponse<bool>().CreateResponse("Password could not be reset", false, false);
            }
            return new BaseResponse<bool>().CreateResponse("", true, result.Succeeded);
        }

        public async Task<BaseResponse<bool>> SignOut(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return new BaseResponse<bool>().CreateResponse($"Invalid Request", false, false);
            }
            await _signInManager.SignOutAsync();

            return new BaseResponse<bool>().CreateResponse("Successfully signed out", true, true);

        }
    }
}
