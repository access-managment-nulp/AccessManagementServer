using AccessManagementApp.Repositories.Interfaces;
using AccessManagementApp.Repository;
using AccessManagementApp.Repository.Facade;
using AccessManagementApp.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagementTests
{
    public class UnitOfWorkMock : IUnitOfWork
    {
        private readonly List<AccessGroup> _accessGroups;
        private AccessGroupRepositoryMock _mockRepository;
        public IAccessRepository Accesses => throw new NotImplementedException();

        public IAccessGroupRepository AccessGroups => _mockRepository ??= new AccessGroupRepositoryMock(_accessGroups);

        public ISpecialityRepository Specialities => throw new NotImplementedException();

        public AccessManagementDbContext Context => throw new NotImplementedException();

        public UnitOfWorkMock(List<AccessGroup> accessGroups)
        {
            _accessGroups = accessGroups;
        }
        public void Dispose()
        {
            return;
        }

        public void SaveChanges()
        {
            return;
        }

        public Task SaveChangesAsync()
        {
            return Task.CompletedTask;
        }
    }
}
