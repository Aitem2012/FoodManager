using FoodManager.Application.DTO.Addresses;
using FoodManager.Domain.Users;

namespace FoodManager.Application.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        public Task<int> CreateAddress(Address address, CancellationToken cancellationToken);
    }
}
