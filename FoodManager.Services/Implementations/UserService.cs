using AutoMapper;
using FoodManager.Application.DTO.Users;
using FoodManager.Application.Interfaces.Repositories;
using FoodManager.Common.Extensions;
using FoodManager.Common.Response;
using FoodManager.Services.Abstracts;
using Microsoft.AspNetCore.Http;

namespace FoodManager.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRespository;
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;
        private readonly ISmsService _smsService;
        private readonly IFileUploadService _uploadService;

        public UserService(IUserRepository userRespository, IAddressService addressService, IMapper mapper, ISmsService smsService, IFileUploadService uploadService)
        {
            _userRespository = userRespository;
            _addressService = addressService;
            _mapper = mapper;
            _smsService = smsService;
            _uploadService = uploadService;
        }

        public async Task<BaseResponse<GetUserResponseObjectDto>> CreateUser(CreateUserDto model, IFormFile file, CancellationToken cancellationToken, string role)
        {
            model.PhoneNumber = model.PhoneNumber.ConvertToPhoneNumber();
            var upload = _uploadService.UploadAvatar(file);
            //TODO: send sms
            //await _smsService.SendSmsAsync(model.PhoneNumber);
            return await _userRespository.CreateUser(model, upload.AvatarUrl, cancellationToken, role);
        }

        public async Task<BaseResponse<GetUserResponseObjectDto>> GetUserByEmail(string email)
        {
            var user = await _userRespository.GetUserByEmail(email);
            if (user == null)
            {
                return new BaseResponse<GetUserResponseObjectDto>().CreateResponse($"No user with email: {email}", false, null);
            }
            return new BaseResponse<GetUserResponseObjectDto>().CreateResponse("", true, _mapper.Map<GetUserResponseObjectDto>(user));
        }

        public async Task<BaseResponse<GetUserResponseObjectDto>> GetUserById(string id)
        {
            var user = await _userRespository.GetUserById(id);
            if (user == null)
            {
                return new BaseResponse<GetUserResponseObjectDto>().CreateResponse($"No user with Id: {id}", false, null);
            }
            return new BaseResponse<GetUserResponseObjectDto>().CreateResponse("", true, _mapper.Map<GetUserResponseObjectDto>(user));
        }

        public async Task<BaseResponse<IEnumerable<GetUserResponseObjectDto>>> GetUsers()
        {
            var users = await _userRespository.GetUsers();
            if (!users.Any())
            {
                return new BaseResponse<IEnumerable<GetUserResponseObjectDto>>().CreateResponse($"No users existed yet", false, null);
            }
            return new BaseResponse<IEnumerable<GetUserResponseObjectDto>>().CreateResponse("", true, _mapper.Map<IEnumerable<GetUserResponseObjectDto>>(users));
        }

        public async Task<BaseResponse<GetUserResponseObjectDto>> UpdateUser(UpdateUserDto model, CancellationToken cancellation)
        {
            return await _userRespository.UpdateUser(model, cancellation);
        }
    }
}
