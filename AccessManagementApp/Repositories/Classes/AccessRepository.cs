﻿using AccessManagementApp.Repositories.Interfaces;
using AccessManagementApp.Repository;
using AccessManagementApp.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessManagementApp.Repositories.Classes
{
    public class AccessRepository : IAccessRepository
    {
        private readonly AccessManagementDbContext _dbContext;
        public AccessRepository(AccessManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ICollection<Access>> GetAll()
        {
            return await _dbContext.Accesses.ToListAsync();
        }

        public async Task<Access> GetById(int id)
        {
            return await _dbContext.Accesses
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<ICollection<Access>> GetFilteredAccesses(string query)
        {
            return await _dbContext.Accesses
                .Where(x => x.Name.Contains(query))
                .ToListAsync();
        }
    }
}
