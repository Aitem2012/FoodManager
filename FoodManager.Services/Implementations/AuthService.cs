using AutoMapper;
using FoodManager.Application.DTO.JWT;
using FoodManager.Application.DTO.Users;
using FoodManager.Common.Response;
using FoodManager.Domain.Users;
using FoodManager.Services.Abstracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FoodManager.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly ILogger<AuthService> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IOptions<JWTData> _JwtData;
        private readonly IMapper _mapper;

        public AuthService(ILogger<AuthService> logger, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, ITokenService tokenService, IOptions<JWTData> jwtData, IMapper mapper)
        {
            _logger = logger;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userManager = userManager;
            _tokenService = tokenService;
            _JwtData = jwtData;
            _mapper = mapper;
        }

        public async Task<BaseResponse<UserLoginResponseDto>> Login(UserLoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new BaseResponse<UserLoginResponseDto>().CreateResponse($"No user with email {model.Email}", false, null);
            }
            var userRoles = await _userManager.GetRolesAsync(user) as List<string>;
            var token = _tokenService.GenerateToken(user, userRoles, _JwtData);
            var userToReturn = _mapper.Map<UserLoginResponseDto>(user);
            userToReturn.Token = token;
            return new BaseResponse<UserLoginResponseDto>().CreateResponse("", true, userToReturn);
        }
    }
}
