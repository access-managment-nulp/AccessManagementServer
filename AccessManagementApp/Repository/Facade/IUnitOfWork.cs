using AccessManagementApp.Repositories.Interfaces;
using AccessManagementApp.Repository.Models;

namespace AccessManagementApp.Repository.Facade
{
    public interface IUnitOfWork : IDisposable
    {
        public IAccessRepository Accesses { get; }
        public IAccessGroupRepository AccessGroups { get; }
        public ISpecialityRepository Specialities { get; }
        public AccessManagementDbContext Context { get; }
        public void SaveChanges();
        public Task SaveChangesAsync();
    }
}
