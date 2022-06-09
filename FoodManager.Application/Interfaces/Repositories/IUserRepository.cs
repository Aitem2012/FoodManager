using FoodManager.Application.DTO.Users;
using FoodManager.Common.Response;
using FoodManager.Domain.Users;

namespace FoodManager.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<BaseResponse<GetUserResponseObject>> CreateUser(CreateUserDto model, CancellationToken cancellationToken);
        Task<BaseResponse<GetUserResponseObject>> UpdateUser(UpdateUserDto model, CancellationToken cancellation);
        Task<AppUser> GetUserById(string id);
        Task<AppUser> GetUserByEmail(string email);
        Task<IEnumerable<AppUser>> GetUsers();
    }
}
