using FoodManager.Application.DTO.Users;
using FoodManager.Common.Response;

namespace FoodManager.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<BaseResponse<GetUserResponseObject>> CreateUser(CreateUserDto model, CancellationToken cancellationToken);
    }
}
