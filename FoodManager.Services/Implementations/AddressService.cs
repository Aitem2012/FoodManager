using AutoMapper;
using FoodManager.Application.DTO.Addresses;
using FoodManager.Application.Interfaces.Repositories;
using FoodManager.Common.Response;
using FoodManager.Domain.Users;
using FoodManager.Services.Abstracts;

namespace FoodManager.Services.Implementations
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;
        public AddressService(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<int> CreateAddress(CreateAddressDto address, CancellationToken cancellationToken)
        {
            var userAddress = _mapper.Map<Address>(address);
            return await _addressRepository.CreateAddress(userAddress, cancellationToken);
        }

        public async Task<BaseResponse<GetAddressResponseObjectDto>> GetAddress(string AppUserId)
        {
            return await _addressRepository.GetAddress(AppUserId);
        }

        public async Task<BaseResponse<GetAddressResponseObjectDto>> UpdateAddressAsync(UpdateAddressDto address, CancellationToken cancellationToken)
        {
            return await _addressRepository.UpdateAddressAsync(address, cancellationToken);
        }
    }
}
