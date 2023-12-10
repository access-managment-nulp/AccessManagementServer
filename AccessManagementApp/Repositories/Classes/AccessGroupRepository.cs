using AccessManagementApp.Repositories.Interfaces;
using AccessManagementApp.Repository;
using AccessManagementApp.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessManagementApp.Repositories.Classes
{
    public class AccessGroupRepository : IAccessGroupRepository
    {

        private readonly AccessManagementDbContext _dbContext;
        public AccessGroupRepository(AccessManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<AccessGroup> Create(AccessGroup item)
        {
            var accesses = await _dbContext.Accesses
                .Where(x => item.Accesses
                        .Select(ma => ma.Id)
                        .Contains(x.Id)
                ).ToListAsync();

            var newAccessGroup = new AccessGroup()
            {
                Name = item.Name,
                Accesses = accesses
            };

            await _dbContext.AccessGroups
                .AddAsync(newAccessGroup);

            await _dbContext
                .SaveChangesAsync();

            return newAccessGroup;
        }

        public async Task<AccessGroup> Delete(int id)
        {
            var accessGroup = await _dbContext.AccessGroups.FirstOrDefaultAsync(x => x.Id == id);

            if (accessGroup != null)
            {
                _dbContext.AccessGroups.Remove(accessGroup);
                await _dbContext.SaveChangesAsync();
            }

            return accessGroup;
        }

        public async Task<ICollection<AccessGroup>> GetAll()
        {
            return await _dbContext.AccessGroups
                .Include(x => x.Accesses)
                .ToListAsync();
        }

        public async Task<AccessGroup> GetById(int id)
        {
            return await _dbContext.AccessGroups
                .Include(x => x.Accesses)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<ICollection<AccessGroup>> GetFilteredAccessGroups(string query)
        {
            return await _dbContext.AccessGroups
                .Include(x => x.Accesses)
                .Where(x => x.Name.Contains(query))
                .ToListAsync();
        }

        public async Task<AccessGroup> Update(AccessGroup item)
        {
            var accessGroup = await _dbContext.AccessGroups
                .Include(x => x.Accesses)
                .FirstOrDefaultAsync(x => x.Id == item.Id);

            var accesses = await _dbContext.Accesses
                .Where(x => item.Accesses
                    .Select(ma => ma.Id)
                    .Contains(x.Id)
                ).ToListAsync();

            if (accessGroup != null && accesses.Count == item.Accesses.Count)
            {
                accessGroup.Name = item.Name;
                accessGroup.Accesses = accesses;
            }
            else
            {
                throw new InvalidOperationException(
                    "Invalid update operation. AccessGroup or Access entities not found or the counts do not match.");
            }

            await _dbContext
                .SaveChangesAsync();

            return accessGroup;
        }
    }
}
