using AutoMapper;
using FoodManager.Application.DTO.Addresses;
using FoodManager.Application.Interfaces.Persistence;
using FoodManager.Application.Interfaces.Repositories;
using FoodManager.Domain.Users;

namespace FoodManager.Application.Implementations.Addresses
{
    public class AddressRespository : IAddressRepository
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public AddressRespository(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreaateAddress(CreateAddressDto address, CancellationToken cancellationToken)
        {
            var userAddress = _mapper.Map<Address>(address);

            _context.Addresses.Add(userAddress);
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
