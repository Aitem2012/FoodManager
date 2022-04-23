using AutoMapper;
using FoodManager.Application.DTO.Users;
using FoodManager.Application.Interfaces.Persistence;
using FoodManager.Application.Interfaces.Repositories;
using FoodManager.Common.Extensions;
using FoodManager.Common.Response;
using FoodManager.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace FoodManager.Application.Implementations.Users
{
    public class UserRespository : IUserRepository
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<UserRespository> _logger;

        public UserRespository(IMapper mapper, IAppDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager, ILogger<UserRespository> logger)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<BaseResponse<GetUserResponseObject>> CreateUser(CreateUserDto model, CancellationToken cancellation)
        {
            _logger.LogInformation($"Creating User Started => Name: {model.FirstName} {model.LastName} | Email: {model.Email} | PhoneNumber: {model.PhoneNumber} | Role: {model.Role} ");
            var user = _mapper.Map<AppUser>(model);
            if (user == null) throw new NotImplementedException();

            
            user.EmailConfirmed = true;
            user.PhoneNumberConfirmed = true;
            user.IsActive = true;
            user.ReferralCode = user.FirstName.GenerateReferralCode();
            user.EmailNotification = true;
            user.SmsNotification = true;
            user.InAppNotification = true;
            user.InviteCode = user.LastName.GenerateRef();
            user.UserName = model.Email;

            if (!_userManager.Users.Any(e => e.UserName.Equals(user.UserName)))
            {
                if (!(await _roleManager.RoleExistsAsync(model.Role)))
                {
                    var role = await _roleManager.CreateAsync(new IdentityRole(model.Role));
                }
                
                // Creating User and Adding to Role
                var result = _userManager.CreateAsync(user, model.Password).Result;
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.Role);
                    await _userManager.AddClaimsAsync(user, new Claim[]{
                        new Claim(ClaimTypes.Role, model.Role),
                        new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                        new Claim(ClaimTypes.GivenName, user.FirstName),
                        new Claim(ClaimTypes.Surname, user.LastName),
                        new Claim(ClaimTypes.Email, user.Email)
                    });
                }

                _logger.LogInformation($"User Successfully Created => Name: {model.FirstName} {model.LastName} | Email: {model.Email} | PhoneNumber: {model.PhoneNumber} | Role: {model.Role}");
            }
            else
            {
                _logger.LogInformation($"User Creation Failed => Name: {model.FirstName} {model.LastName} | Email: {model.Email} | PhoneNumber: {model.PhoneNumber} | Role: {model.Role}");
                throw new Exception("Username exist exception");
            }

            return new BaseResponse<GetUserResponseObject>().CreateResponse("", true, _mapper.Map<GetUserResponseObject>(user));
        }
    }
}
