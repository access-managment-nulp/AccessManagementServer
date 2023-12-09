using AccessManagementApp.Entities;
using AccessManagementApp.Repositories.Classes;
using AccessManagementApp.Repositories.Interfaces;
using AccessManagementApp.Repository.Facade;
using AccessManagementApp.Repository.Models;
using AccessManagementApp.Services.Interfaces;
using AutoMapper;

namespace AccessManagementApp.Services.Classes
{
    public class AccessGroupService : IAccessGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AccessGroupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AccessGroupModel> Create(CreateAccessGroupModel item)
        {
            if(item == null)
                throw new ArgumentNullException(nameof(item));

            if(string.IsNullOrEmpty(item.Name))
                throw new ArgumentNullException(nameof(item.Name));

            if (item.Accesses == null || item.Accesses.Count == 0)
                throw new ArgumentNullException(nameof(item.Accesses));

            var accessGroup = _mapper.Map<AccessGroup>(item);

            var createdAccessGroup = await _unitOfWork.AccessGroups.Create(accessGroup);

            var result = _mapper.Map<AccessGroupModel>(createdAccessGroup);

            return result;
        }

        public async Task<AccessGroup> Delete(int id)
        {
            var itemToDelete = await _unitOfWork.AccessGroups.GetById(id);

            if (itemToDelete == null)
                throw new KeyNotFoundException("Unable to delete non-existing item");

            var deletedAccessGroup = _mapper.Map<AccessGroup>(await _unitOfWork.AccessGroups.Delete(id));

            return deletedAccessGroup;
        }

        public async Task<ICollection<AccessGroupModel>> GetAll()
        {
            var accessGroups = await _unitOfWork.AccessGroups.GetAll();

            return _mapper.Map<ICollection<AccessGroupModel>>(accessGroups);
        }

        public async Task<AccessGroupModel> GetById(int id)
        {
            var accessGroups = await _unitOfWork.AccessGroups.GetById(id);

            return _mapper.Map<AccessGroupModel>(accessGroups);
        }

        public async Task<ICollection<AccessGroupModel>> GetFilteredAccessGroups(string query)
        {
            var accessGroups = await _unitOfWork.AccessGroups.GetFilteredAccessGroups(query);

            return _mapper.Map<ICollection<AccessGroupModel>>(accessGroups);
        }

        public async Task<AccessGroupModel> Update(UpdateAccessGroupModel item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (string.IsNullOrEmpty(item.Name))
                throw new ArgumentNullException(nameof(item.Name));

            if (item.Accesses == null || item.Accesses.Count == 0)
                throw new ArgumentNullException(nameof(item.Accesses));

            var itemToUpdate = await _unitOfWork.AccessGroups.GetById(item.Id);

            if (itemToUpdate == null)
                throw new KeyNotFoundException("Unable to edit non-existing item");

            var accessGroup = _mapper.Map<AccessGroup>(item);

            var updatedAccessGroup = await _unitOfWork.AccessGroups.Update(accessGroup);

            var result = _mapper.Map<AccessGroupModel>(updatedAccessGroup);

            return result;
        }
    }
}
