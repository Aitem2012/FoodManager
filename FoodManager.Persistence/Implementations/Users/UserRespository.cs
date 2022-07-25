using AutoMapper;
using FoodManager.Application.DTO.Users;
using FoodManager.Application.Interfaces.Persistence;
using FoodManager.Application.Interfaces.Repositories;
using FoodManager.Common.Extensions;
using FoodManager.Common.Response;
using FoodManager.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace FoodManager.Persistence.Implementations.Users
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

        public async Task<BaseResponse<GetUserResponseObjectDto>> CreateUser(CreateUserDto model, string imageUrl, CancellationToken cancellation, string role = "")
        {
            _logger.LogInformation($"Creating User Started => Name: {model.FirstName} {model.LastName} | Email: {model.Email} | PhoneNumber: {model.PhoneNumber} | Role: {role} ");
            var user = _mapper.Map<AppUser>(model);
            if (user == null) throw new NotImplementedException();

            user.ImageUrl = imageUrl;
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
                var userRole = new IdentityResult();
                if (!string.IsNullOrEmpty(role) && !(await _roleManager.RoleExistsAsync(role)))
                {
                    userRole = await _roleManager.CreateAsync(new IdentityRole(role));
                }
                
                // Creating User and Adding to Role
                var result = _userManager.CreateAsync(user, model.Password).Result;
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, role);
                    await _userManager.AddClaimsAsync(user, new Claim[]{
                        new Claim(ClaimTypes.Role, role),
                        new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                        new Claim(ClaimTypes.GivenName, user.FirstName),
                        new Claim(ClaimTypes.Surname, user.LastName),
                        new Claim(ClaimTypes.Email, user.Email)
                    });
                }

                _logger.LogInformation($"User Successfully Created => Name: {model.FirstName} {model.LastName} | Email: {model.Email} | PhoneNumber: {model.PhoneNumber} | Role: {role}");
            }
            else
            {
                _logger.LogInformation($"User Creation Failed => Name: {model.FirstName} {model.LastName} | Email: {model.Email} | PhoneNumber: {model.PhoneNumber} | Role: {role}");
                throw new Exception("Username exist exception");
            }

            return new BaseResponse<GetUserResponseObjectDto>().CreateResponse("", true, _mapper.Map<GetUserResponseObjectDto>(user));
        }

        public async Task<AppUser> GetUserByEmail(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            if (user == null)
            {
                _logger.LogInformation($"No user with email {email}");
                return null;
            }
            return user;
        }

        public async Task<AppUser> GetUserById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                _logger.LogInformation($"No user with Id: {id}");
                return null;
            }
            return user;
        }

        public async Task<IEnumerable<AppUser>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            if (!users.Any())
            {
                _logger.LogInformation($"A call to all users made at {DateTime.Now} but no users exist in the db");
            }
            return users;
        }

        public async Task<BaseResponse<GetUserResponseObjectDto>> UpdateUser(UpdateUserDto model, CancellationToken cancellation)
        {
            _logger.LogInformation($"User update called for user with Id: {model.Id} at {DateTime.Now}");
            var userInDb = await _context.Users.FirstOrDefaultAsync(x => x.Id.Equals(model.Id), cancellation);
            if (userInDb == null)
            {
                _logger.LogInformation($"No User with ID: {model.Id}");
                return new BaseResponse<GetUserResponseObjectDto>().CreateResponse($"No user with Id: {model.Id}", false, null);
            }
            var user = _mapper.Map(model, userInDb);
            user.InviteCode = model.LastName.GenerateRef();
            user.ReferralCode = model.FirstName.GenerateReferralCode();
            _context.Users.Attach(user);
            if (!(await _context.SaveChangesAsync(cancellation)> 0))
            {
                _logger.LogInformation($"User could not be updated.");
                return new BaseResponse<GetUserResponseObjectDto>().CreateResponse($"User could not be updated.", false, null);
            }
            return new BaseResponse<GetUserResponseObjectDto>().CreateResponse("", true, _mapper.Map<GetUserResponseObjectDto>(user));
        }
    }
}
