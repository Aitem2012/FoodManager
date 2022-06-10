using FoodManager.Application.DTO.Addresses;
using FoodManager.Common.Response;

namespace FoodManager.Services.Abstracts
{
    public interface IAddressService
    {
        public Task<int> CreateAddress(CreateAddressDto address, CancellationToken cancellationToken);
        public Task<BaseResponse<GetAddressResponseObjectDto>> GetAddress(string AppUserId);
        public Task<BaseResponse<GetAddressResponseObjectDto>> UpdateAddressAsync(UpdateAddressDto address, CancellationToken cancellationToken);
    }
}
