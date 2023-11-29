using AccessManagementApp.Entities;
using AccessManagementApp.Repository.Models;

namespace AccessManagementApp.Services.Interfaces
{
    public interface IAccessGroupService
    {
        Task<AccessGroupModel> Create(CreateAccessGroupModel item);
        Task<AccessGroupModel> Update(UpdateAccessGroupModel item);
        Task<AccessGroup> Delete(int id);
        Task<ICollection<AccessGroupModel>> GetAll();
        Task<AccessGroupModel> GetById(int id);
        Task<ICollection<AccessGroupModel>> GetFilteredAccessGroups(string query);
    }
}
