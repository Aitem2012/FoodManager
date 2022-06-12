﻿using FoodManager.Application.DTO.Users;
using FoodManager.Common.Response;

namespace FoodManager.Services.Abstracts
{
    public interface IUserService
    {
        Task<BaseResponse<GetUserResponseObjectDto>> CreateUser(CreateUserDto model, CancellationToken cancellationToken, string role);
        Task<BaseResponse<GetUserResponseObjectDto>> UpdateUser(UpdateUserDto model, CancellationToken cancellation);
        Task<BaseResponse<GetUserResponseObjectDto>> GetUserById(string id);
        Task<BaseResponse<GetUserResponseObjectDto>> GetUserByEmail(string email);
        Task<BaseResponse<IEnumerable<GetUserResponseObjectDto>>> GetUsers();
    }
}
