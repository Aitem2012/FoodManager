﻿using AutoMapper;
using FoodManager.Application.DTO.Addresses;
using FoodManager.Application.DTO.Categories;
using FoodManager.Application.DTO.Menus;
using FoodManager.Application.DTO.OrderItems;
using FoodManager.Application.DTO.Orders;
using FoodManager.Application.DTO.Users;
using FoodManager.Domain.Enums;
using FoodManager.Domain.Menus;
using FoodManager.Domain.Orders;
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
            CreateMap<CreateMenuDto, Menu>();
            CreateMap<UpdateMenuDto, Menu>();
            CreateMap<Menu, GetMenuResponseObjectDto>()
                .ForMember(dest => dest.Size, opt => opt.MapFrom(src => (Size)src.Size));

            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, GetCategoryResponseObjectDto>()
                .ForMember(dest => dest.Menus, opt => opt.MapFrom(src => src.Menus.Count));

            CreateMap<CreateOrderDto, Order>();
            CreateMap<Order, GetOrderResponseObjectDto>();

            CreateMap<CreateOrderItemDto, OrderItem>();
            CreateMap<OrderItem, GetOrderItemResponseObjectDto>();
            CreateMap<GetOrderResponseObjectDto, GetOrderItemResponseObjectDto>();
        }
    }
}
