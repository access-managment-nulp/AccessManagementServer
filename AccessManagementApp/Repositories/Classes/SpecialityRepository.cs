using AccessManagementApp.Repositories.Interfaces;
using AccessManagementApp.Repository;
using AccessManagementApp.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessManagementApp.Repositories.Classes
{
    public class SpecialityRepository : ISpecialityRepository
    {
        private static SpecialityRepository _instance;
        public static SpecialityRepository GetInstance(AccessManagementDbContext dbContext) {
            if(_instance == null) {
                _instance = new(dbContext);
            }
            return _instance;
        }
        
        private readonly AccessManagementDbContext _dbContext;
        public SpecialityRepository(AccessManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ICollection<Speciality>> GetAll()
        {
            return await _dbContext.Specialities
                .Include(x => x.AccessGroups)
                .Include(x => x.Accesses)
                .ToListAsync();
        }

        public async Task<Speciality> GetById(int id)
        {
            return await _dbContext.Specialities
                .Include(x => x.AccessGroups)
                .Include(x => x.Accesses)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<ICollection<Speciality>> GetFilteredSpecialities(string query)
        {
            return await _dbContext.Specialities
                .Include(x => x.AccessGroups)
                .Include(x => x.Accesses)
                .Where(x => x.Name.Contains(query))
                .ToListAsync();
        }

        public async Task<Speciality> Update(Speciality item)
        {
            var speciality = await _dbContext.Specialities
                .Include(x => x.AccessGroups)
                .Include(x => x.Accesses)
                .FirstOrDefaultAsync(x => x.Id == item.Id);

            var accessGroups = await _dbContext.AccessGroups
                .Where(x => item.AccessGroups
                    .Select(ma => ma.Id)
                    .Contains(x.Id)
                ).ToListAsync();

            var accesses = await _dbContext.Accesses
                .Where(x => item.Accesses
                    .Select(ma => ma.Id)
                    .Contains(x.Id)
                ).ToListAsync();

            if (speciality != null && accessGroups.Count == item.AccessGroups.Count && accesses.Count == item.Accesses.Count)
            {
                speciality.Name = item.Name;
                speciality.AccessGroups = accessGroups;
                speciality.Accesses = accesses;
            }
            else
            {
                throw new InvalidOperationException(
                    "Invalid update operation. AccessGroup or Access entities not found or the counts do not match.");
            }

            await _dbContext
                .SaveChangesAsync();

            return speciality;
        }
    }
}
