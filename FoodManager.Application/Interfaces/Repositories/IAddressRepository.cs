using FoodManager.Application.DTO.Addresses;

namespace FoodManager.Application.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        public Task<int> CreaateAddress(CreateAddressDto address, CancellationToken cancellationToken);
    }
}
