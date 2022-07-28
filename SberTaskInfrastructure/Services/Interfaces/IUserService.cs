using SberTaskInfrastructure.Models;

namespace SberTaskInfrastructure.Services
{
    public interface IUserService
    {
        Task<ResponseModel> Login(UserLogin userLogin);
        Task<ResponseModel> Register(UserRegistration userRegistration);
    }
}
