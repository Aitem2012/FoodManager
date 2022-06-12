using FoodManager.Application.DTO.Addresses;
using FoodManager.Common.Response;
using FoodManager.Domain.Users;

namespace FoodManager.Application.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        public Task<int> CreateAddress(Address address, CancellationToken cancellationToken);
        public Task<BaseResponse<GetAddressResponseObjectDto>> GetAddress(string AppUserId);
        public Task<BaseResponse<GetAddressResponseObjectDto>> UpdateAddressAsync(UpdateAddressDto address, CancellationToken cancellationToken);
    }
}
