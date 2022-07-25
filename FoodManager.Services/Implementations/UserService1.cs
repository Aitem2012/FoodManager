using AutoMapper;
using FoodManager.Application.DTO.Users;
using FoodManager.Application.Interfaces.Abstracts;
using FoodManager.Application.Interfaces.Repositories;
using FoodManager.Common.Extensions;
using FoodManager.Common.Response;
using FoodManager.Domain.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FoodManager.Application.Services.Implementations
{
    public class UserService1 : IUserService
    {
        private readonly IUserRepository _userRespository;
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;
        private readonly ISmsService _smsService;
        private readonly IFileUploadService _uploadService;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AppUser> _userManager;
        public UserService1(IUserRepository userRespository, IAddressService addressService, IMapper mapper, ISmsService smsService, IFileUploadService uploadService, IHttpContextAccessor httpContext, UserManager<AppUser> userManager)
        {
            _userRespository = userRespository;
            _addressService = addressService;
            _mapper = mapper;
            _smsService = smsService;
            _uploadService = uploadService;
            _httpContext = httpContext;
            _userManager = userManager;
        }

        public async Task<BaseResponse<GetUserResponseObjectDto>> CreateUser(CreateUserDto model, CancellationToken cancellationToken, string role, IFormFile file = null)
        {
            model.PhoneNumber = model.PhoneNumber.ConvertToPhoneNumber();
            string imageUrl = string.Empty;
            if (file != null)
            {
                imageUrl = _uploadService.UploadAvatar(file).AvatarUrl;
            }
            //TODO: send sms
            //await _smsService.SendSmsAsync(model.PhoneNumber);
            return await _userRespository.CreateUser(model, imageUrl, cancellationToken, role);
        }

        public async Task<BaseResponse<GetUserResponseObjectDto>> GetUserByEmail(string email)
        {
            if (!await IsCorrectUserAuthenticated(email: email))
            {
                return new BaseResponse<GetUserResponseObjectDto>().CreateResponse("Unauthorized access", false, null); ;
            }
            var user = await _userRespository.GetUserByEmail(email);
            if (user == null)
            {
                return new BaseResponse<GetUserResponseObjectDto>().CreateResponse($"No user with email: {email}", false, null);
            }
            return new BaseResponse<GetUserResponseObjectDto>().CreateResponse("", true, _mapper.Map<GetUserResponseObjectDto>(user));
        }

        public async Task<BaseResponse<GetUserResponseObjectDto>> GetUserById(string id)
        {
            if (!await IsCorrectUserAuthenticated(id))
            {
                return new BaseResponse<GetUserResponseObjectDto>().CreateResponse("Unauthorized access", false, null); ;
            }
            var user = await _userRespository.GetUserById(id);
            if (user == null)
            {
                return new BaseResponse<GetUserResponseObjectDto>().CreateResponse($"No user with Id: {id}", false, null);
            }
            return new BaseResponse<GetUserResponseObjectDto>().CreateResponse("", true, _mapper.Map<GetUserResponseObjectDto>(user));
        }

        public async Task<BaseResponse<IEnumerable<GetUserResponseObjectDto>>> GetUsers()
        {
            if (!await IsCorrectUserAuthenticated())
            {
                return new BaseResponse<IEnumerable<GetUserResponseObjectDto>>().CreateResponse("Unauthorized access", false, null); ;
            }
            var users = await _userRespository.GetUsers();
            if (!users.Any())
            {
                return new BaseResponse<IEnumerable<GetUserResponseObjectDto>>().CreateResponse($"No users existed yet", false, null);
            }
            return new BaseResponse<IEnumerable<GetUserResponseObjectDto>>().CreateResponse("", true, _mapper.Map<IEnumerable<GetUserResponseObjectDto>>(users));
        }

        public async Task<BaseResponse<GetUserResponseObjectDto>> UpdateUser(UpdateUserDto model, CancellationToken cancellation)
        {
            if (!await IsCorrectUserAuthenticated(id: model.Id))
            {
                return new BaseResponse<GetUserResponseObjectDto>().CreateResponse("Unauthorized to perform this action", false, null);
            }
            return await _userRespository.UpdateUser(model, cancellation);
        }

        private async Task<AppUser> GetCurrentUser() => await _userManager.GetUserAsync(_httpContext.HttpContext.User);

        private async Task<bool> IsCorrectUserAuthenticated(string id = "", string email = "")
        {
            var user = await GetCurrentUser();
            var loggedInUserRole = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.Role);
            var userIdIsCorrect = false;
            var userEmailIsCorrect = false;
            if (email.StringNotNullOrEmpty())
            {
                userEmailIsCorrect = user.Email.Equals(email);
            }
            if (id.StringNotNullOrEmpty())
            {
                userIdIsCorrect = user.Id.Equals(id);
            }
            if (loggedInUserRole.Equals("admin"))
            {
                return true;
            }
            if (!userIdIsCorrect)
            {
                return false;
            }
            if (!userEmailIsCorrect)
            {
                return false;
            }

            return true;
        }
    }
}
