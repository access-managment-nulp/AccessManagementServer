using AccessManagementApp.Entities;
using AccessManagementApp.Repositories.Classes;
using AccessManagementApp.Repositories.Interfaces;
using AccessManagementApp.Repository.Models;
using AccessManagementApp.Services.Interfaces;
using AutoMapper;

namespace AccessManagementApp.Services.Classes
{
    public class AccessGroupService : IAccessGroupService
    {
        private readonly IAccessGroupRepository _accessGroupRepository;
        private readonly IMapper _mapper;
        public AccessGroupService(IAccessGroupRepository accessGroupRepository, IMapper mapper)
        {
            _accessGroupRepository = accessGroupRepository;
            _mapper = mapper;
        }
        public async Task<AccessGroupModel> Create(CreateAccessGroupModel item)
        {
            var accessGroup = _mapper.Map<AccessGroup>(item);

            var createdAccessGroup = await _accessGroupRepository.Create(accessGroup);

            var result = _mapper.Map<AccessGroupModel>(createdAccessGroup);

            return result;
        }

        public async Task<AccessGroup> Delete(int id)
        {
            var deletedAccessGroup = _mapper.Map<AccessGroup>(await _accessGroupRepository.Delete(id));

            return deletedAccessGroup;
        }

        public async Task<ICollection<AccessGroupModel>> GetAll()
        {
            var accessGroups = await _accessGroupRepository.GetAll();

            return _mapper.Map<ICollection<AccessGroupModel>>(accessGroups);
        }

        public async Task<AccessGroupModel> GetById(int id)
        {
            var accessGroups = await _accessGroupRepository.GetById(id);

            return _mapper.Map<AccessGroupModel>(accessGroups);
        }

        public async Task<ICollection<AccessGroupModel>> GetFilteredAccessGroups(string query)
        {
            var accessGroups = await _accessGroupRepository.GetFilteredAccessGroups(query);

            return _mapper.Map<ICollection<AccessGroupModel>>(accessGroups);
        }

        public async Task<AccessGroupModel> Update(UpdateAccessGroupModel item)
        {
            var accessGroup = _mapper.Map<AccessGroup>(item);

            var updatedAccessGroup = await _accessGroupRepository.Update(accessGroup);

            var result = _mapper.Map<AccessGroupModel>(updatedAccessGroup);

            return result;
        }
    }
}
