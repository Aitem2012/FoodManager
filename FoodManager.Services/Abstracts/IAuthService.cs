using FoodManager.Application.DTO.Users;
using FoodManager.Common.Response;

namespace FoodManager.Services.Abstracts
{
    public interface IAuthService
    {
        public Task<BaseResponse<UserLoginResponseDto>> Login(UserLoginDto model);
        public Task<BaseResponse<bool>> ResetPassword (ResetUserPasswordDto model);
        public Task<BaseResponse<string>> ForgotPassword(string email);
        public Task<BaseResponse<bool>> SignOut(string email);
    }
}
