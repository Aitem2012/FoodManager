﻿using AutoMapper;
using FoodManager.Application.DTO.Addresses;
using FoodManager.Application.Interfaces.Persistence;
using FoodManager.Application.Interfaces.Repositories;
using FoodManager.Common.Response;
using FoodManager.Domain.Users;
using Microsoft.EntityFrameworkCore;

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

        public async Task<int> CreateAddress(Address address, CancellationToken cancellationToken)
        {
            _context.Addresses.Add(address);
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<BaseResponse<GetAddressResponseObject>> GetAddress(string AppUserId)
        {
            var address = await _context.Addresses.SingleOrDefaultAsync(x => x.AppUserId.Equals(AppUserId));
            return new BaseResponse<GetAddressResponseObject>().CreateResponse("", true, _mapper.Map<GetAddressResponseObject>(address));
        }

        public async Task<BaseResponse<GetAddressResponseObject>> UpdateAddressAsync(UpdateAddressDto address, CancellationToken cancellationToken)
        {
            var addressInDb = await _context.Addresses.SingleOrDefaultAsync(x => x.Id.Equals(address.AddressId) && x.AppUserId.Equals(address.AppUserId));
            var theAddress = _mapper.Map(address, addressInDb);
            _context.Addresses.Attach(theAddress);
            await _context.SaveChangesAsync(cancellationToken);
            return new BaseResponse<GetAddressResponseObject>().CreateResponse("", true, _mapper.Map<GetAddressResponseObject>(theAddress));
        }
    }
}
