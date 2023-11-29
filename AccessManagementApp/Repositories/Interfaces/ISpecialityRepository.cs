using AccessManagementApp.Repository.Models;

namespace AccessManagementApp.Repositories.Interfaces
{
    public interface ISpecialityRepository
    {
        Task<Speciality> Update(Speciality item);
        Task<ICollection<Speciality>> GetAll();
        Task<Speciality> GetById(int id);
        Task<ICollection<Speciality>> GetFilteredSpecialities(string query);
    }
}
