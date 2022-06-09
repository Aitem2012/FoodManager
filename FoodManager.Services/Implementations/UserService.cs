using AutoMapper;
using FoodManager.Application.DTO.Users;
using FoodManager.Application.Interfaces.Repositories;
using FoodManager.Common.Response;
using FoodManager.Services.Abstracts;

namespace FoodManager.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRespository;
        private readonly IAddressService _addressService;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRespository, IAddressService addressService, IMapper mapper)
        {
            _userRespository = userRespository;
            _addressService = addressService;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetUserResponseObject>> CreateUser(CreateUserDto model, CancellationToken cancellationToken)
        {
            var user =  await _userRespository.CreateUser(model, cancellationToken);
            var address = model.Address;
            address.AppUserId = user.Data.Id;
            await _addressService.CreateAddress(address, cancellationToken) ;
            return user;
        }

        public async Task<BaseResponse<GetUserResponseObject>> GetUserByEmail(string email)
        {
            var user = await _userRespository.GetUserByEmail(email);
            if (user == null)
            {
                return new BaseResponse<GetUserResponseObject>().CreateResponse($"No user with email: {email}", false, null);
            }
            return new BaseResponse<GetUserResponseObject>().CreateResponse("", true, _mapper.Map<GetUserResponseObject>(user));
        }

        public async Task<BaseResponse<GetUserResponseObject>> GetUserById(string id)
        {
            var user = await _userRespository.GetUserById(id);
            if (user == null)
            {
                return new BaseResponse<GetUserResponseObject>().CreateResponse($"No user with Id: {id}", false, null);
            }
            return new BaseResponse<GetUserResponseObject>().CreateResponse("", true, _mapper.Map<GetUserResponseObject>(user));
        }

        public async Task<BaseResponse<IEnumerable<GetUserResponseObject>>> GetUsers()
        {
            var users = await _userRespository.GetUsers();
            if (!users.Any())
            {
                return new BaseResponse<IEnumerable<GetUserResponseObject>>().CreateResponse($"No users existed yet", false, null);
            }
            return new BaseResponse<IEnumerable<GetUserResponseObject>>().CreateResponse("", true, _mapper.Map<IEnumerable<GetUserResponseObject>>(users));
        }

        public async Task<BaseResponse<GetUserResponseObject>> UpdateUser(UpdateUserDto model, CancellationToken cancellation)
        {
            return await _userRespository.UpdateUser(model, cancellation);
        }
    }
}
