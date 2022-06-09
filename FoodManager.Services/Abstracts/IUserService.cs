using FoodManager.Application.DTO.Users;
using FoodManager.Common.Response;

namespace FoodManager.Services.Abstracts
{
    public interface IUserService
    {
        Task<BaseResponse<GetUserResponseObject>> CreateUser(CreateUserDto model, CancellationToken cancellationToken);
        Task<BaseResponse<GetUserResponseObject>> UpdateUser(UpdateUserDto model, CancellationToken cancellation);
        Task<BaseResponse<GetUserResponseObject>> GetUserById(string id);
        Task<BaseResponse<GetUserResponseObject>> GetUserByEmail(string email);
        Task<BaseResponse<IEnumerable<GetUserResponseObject>>> GetUsers();
    }
}
