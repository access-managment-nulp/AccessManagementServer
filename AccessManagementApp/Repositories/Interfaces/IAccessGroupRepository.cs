using AccessManagementApp.Repository.Models;

namespace AccessManagementApp.Repositories.Interfaces
{
    public interface IAccessGroupRepository
    {
        Task<AccessGroup> Create(AccessGroup item);
        Task<AccessGroup> Update(AccessGroup item);
        Task<AccessGroup> Delete(int id);
        Task<ICollection<AccessGroup>> GetAll();
        Task<AccessGroup> GetById(int id);
        Task<ICollection<AccessGroup>> GetFilteredAccessGroups(string query);
    }
}
