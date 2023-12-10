using AccessManagementApp.Repositories.Classes;
using AccessManagementApp.Repositories.Interfaces;

namespace AccessManagementApp.Repository.Facade
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AccessManagementDbContext _context;

        public UnitOfWork(AccessManagementDbContext context)
        {
            _context = context;
        }

        public IAccessRepository? _accesses;
        public IAccessGroupRepository? _accessGroups;
        public ISpecialityRepository? _specialities;
        public IAccessRepository Accesses => _accesses ??= new AccessRepository(_context);
        public IAccessGroupRepository AccessGroups => _accessGroups ??= new AccessGroupRepository(_context);
        public ISpecialityRepository Specialities => _specialities ??= new SpecialityRepository(_context);

        public AccessManagementDbContext Context => _context;

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        #region Disposable
        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed is false)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
        #endregion
    }
}
