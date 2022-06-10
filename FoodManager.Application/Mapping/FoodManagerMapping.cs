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
            CreateMap<AppUser, GetUserResponseObjectDto>();
            CreateMap<CreateAddressDto, Address>();
            CreateMap<Address, GetAddressResponseObjectDto>();

            CreateMap<UpdateUserDto, AppUser>();
            CreateMap<AppUser, UserLoginResponseDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => $"{x.FirstName} {x.LastName}"));

            CreateMap<UpdateAddressDto, Address>();
        }
    }
}
