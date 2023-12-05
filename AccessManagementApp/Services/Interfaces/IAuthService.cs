using AccessManagementApp.Models;
using AccessManagementApp.Repository.Models;

namespace AccessManagementApp.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(RegisterModel model);

        Task<AuthUser> Login(LoginModel model);
    }
}
