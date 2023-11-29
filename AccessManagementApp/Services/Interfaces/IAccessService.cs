using AccessManagementApp.Entities;
using AccessManagementApp.Repository.Models;

namespace AccessManagementApp.Services.Interfaces
{
    public interface IAccessService
    {
        Task<ICollection<AccessModel>> GetAll();
        Task<AccessModel> GetById(int id);
        Task<ICollection<AccessModel>> GetFilteredAccesses(string query);
    }
}
