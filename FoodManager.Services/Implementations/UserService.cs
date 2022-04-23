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

        public UserService(IUserRepository userRespository, IAddressService addressService)
        {
            _userRespository = userRespository;
            _addressService = addressService;
        }

        public async Task<BaseResponse<GetUserResponseObject>> CreateUser(CreateUserDto model, CancellationToken cancellationToken)
        {
            var user =  await _userRespository.CreateUser(model, cancellationToken);
            var address = model.Address;
            address.AppUserId = user.Data.Id;
            await _addressService.CreaateAddress(address, cancellationToken) ;
            return user;
        }
    }
}
