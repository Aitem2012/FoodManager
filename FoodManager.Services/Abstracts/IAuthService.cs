using FoodManager.Application.DTO.Users;
using FoodManager.Common.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodManager.Services.Abstracts
{
    public interface IAuthService
    {
        public Task<BaseResponse<UserLoginResponseDto>> Login(UserLoginDto model);
    }
}
