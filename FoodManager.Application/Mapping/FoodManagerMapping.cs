using AutoMapper;
using FoodManager.Application.DTO.Addresses;
using FoodManager.Application.DTO.Users;
using FoodManager.Domain.Users;

namespace FoodManager.Application.Mapping
{
    public class FoodManagerMapping : Profile
    {
        public FoodManagerMapping()
        {
            AllowNullCollections = true;
            AllowNullDestinationValues = true;

            CreateMap<CreateUserDto, AppUser>();
            CreateMap<AppUser, GetUserResponseObject>();
            CreateMap<CreateAddressDto, Address>();
            CreateMap<Address, GetAddressResponseObject>();
        }
    }
}
