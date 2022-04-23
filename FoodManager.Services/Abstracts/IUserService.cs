using FoodManager.Application.DTO.Users;
using FoodManager.Common.Response;

namespace FoodManager.Services.Abstracts
{
    public interface IUserService
    {
        Task<BaseResponse<GetUserResponseObject>> CreateUser(CreateUserDto model, CancellationToken cancellationToken);
    }
}
