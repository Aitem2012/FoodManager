using FoodManager.Application.DTO.Addresses;

namespace FoodManager.Services.Abstracts
{
    public interface IAddressService
    {
        public Task<int> CreaateAddress(CreateAddressDto address, CancellationToken cancellationToken);
    }
}
