using AccessManagementApp.Repositories.Interfaces;
using AccessManagementApp.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessManagementTests
{
    public class AccessGroupRepositoryMock : IAccessGroupRepository
    {
        private List<AccessGroup> AccessGroups { get; set; }

        public AccessGroupRepositoryMock(List<AccessGroup> accessGroups)
        {
            AccessGroups = accessGroups.ToList();
        }
        public async Task<AccessGroup> Create(AccessGroup item)
        {
            item.Id = AccessGroups.Max(x => x.Id) + 1;
            AccessGroups.Add(item);

            return item;
        }

        public async Task<AccessGroup> Delete(int id)
        {
            var agToDelete = AccessGroups.Find(x => x.Id == id);
            
            if (agToDelete != null)
            {
                AccessGroups.Remove(agToDelete);
                return agToDelete;
            }

            return null;
        }

        public async Task<ICollection<AccessGroup>> GetAll()
        {
            return AccessGroups.ToList();
        }

        public async Task<AccessGroup> GetById(int id)
        {
            return AccessGroups.Find(x => x.Id == id);
        }

        public async Task<ICollection<AccessGroup>> GetFilteredAccessGroups(string query)
        {
            return AccessGroups.Where(x => x.Name.Contains(query)).ToList();
        }

        public async Task<AccessGroup> Update(AccessGroup item)
        {
            var agIndexToUpdate = AccessGroups.FindIndex(x => x.Id == item.Id);

            AccessGroups[agIndexToUpdate] = item;

            return item;
        }
    }
}
