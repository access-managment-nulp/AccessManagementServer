using AccessManagementApp.Repository.Models;

namespace AccessManagementApp.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Create(User user); 
        Task<User?> GetUserByEmail(string email);
    }
}
