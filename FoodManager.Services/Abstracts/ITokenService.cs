using FoodManager.Application.DTO.JWT;
using FoodManager.Domain.Users;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodManager.Services.Abstracts
{
    public interface ITokenService
    {
        public string GenerateToken(AppUser user, List<string> userRoles, IOptions<JWTData> options);
    }
}
