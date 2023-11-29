using AccessManagementApp.Entities;
using AccessManagementApp.Models;
using AccessManagementApp.Repository.Models;

namespace AccessManagementApp.Services.Interfaces
{
    public interface ISpecialityService
    {
        Task<SpecialityModel> Update(UpdateSpecialityModel item);
        Task<ICollection<SpecialityModel>> GetAll();
        Task<SpecialityModel> GetById(int id);
        Task<ICollection<SpecialityModel>> GetFilteredSpecialities(string query);
    }
}
