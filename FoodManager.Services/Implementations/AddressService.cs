using FoodManager.Application.DTO.Addresses;
using FoodManager.Application.Interfaces.Repositories;
using FoodManager.Services.Abstracts;

namespace FoodManager.Services.Implementations
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<int> CreaateAddress(CreateAddressDto address, CancellationToken cancellationToken)
        {
            return await _addressRepository.CreaateAddress(address, cancellationToken);
        }
    }
}
