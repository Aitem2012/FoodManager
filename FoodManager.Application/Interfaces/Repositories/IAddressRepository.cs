using FoodManager.Application.DTO.Addresses;
using FoodManager.Common.Response;
using FoodManager.Domain.Users;

namespace FoodManager.Application.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        public Task<int> CreateAddress(Address address, CancellationToken cancellationToken);
        public Task<BaseResponse<GetAddressResponseObject>> GetAddress(string AppUserId);
        public Task<BaseResponse<GetAddressResponseObject>> UpdateAddressAsync(UpdateAddressDto address, CancellationToken cancellationToken);
    }
}
