using AccessManagementApp.Repository.Models;

namespace AccessManagementApp.Repositories.Interfaces
{
    public interface IAccessRepository
    {
        Task<ICollection<Access>> GetAll();
        Task<Access> GetById(int id);
        Task<ICollection<Access>> GetFilteredAccesses(string query);
    }
}
