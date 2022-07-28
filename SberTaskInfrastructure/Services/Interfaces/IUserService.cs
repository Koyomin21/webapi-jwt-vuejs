using SberTaskInfrastructure.Models;
using System.IdentityModel.Tokens.Jwt;

namespace SberTaskInfrastructure.Services
{
    public interface IUserService
    {
        Task<ResponseResult<TokenModel>> Login(UserLogin userLogin);
        Task<ResponseResult> Register(UserRegistration userRegistration);
    }
}
