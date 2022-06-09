using FoodManager.Application.DTO.Addresses;

namespace FoodManager.Services.Abstracts
{
    public interface IAddressService
    {
        public Task<int> CreateAddress(CreateAddressDto address, CancellationToken cancellationToken);
    }
}
