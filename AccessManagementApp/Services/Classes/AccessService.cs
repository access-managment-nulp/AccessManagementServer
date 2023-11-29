using AccessManagementApp.Entities;
using AccessManagementApp.Repositories.Interfaces;
using AccessManagementApp.Repository.Models;
using AccessManagementApp.Services.Interfaces;
using AutoMapper;

namespace AccessManagementApp.Services.Classes
{
    public class AccessService : IAccessService
    {
        private readonly IAccessRepository _accessRepository;
        private readonly IMapper _mapper;

        public AccessService(IAccessRepository accessRepository, IMapper mapper)
        {
            _accessRepository = accessRepository;
            _mapper = mapper;
        }
        public async Task<ICollection<AccessModel>> GetAll()
        {
            var accesses = await _accessRepository.GetAll();
            
            return _mapper.Map<ICollection<AccessModel>>(accesses);
        }

        public async Task<AccessModel> GetById(int id)
        {
            var access = await _accessRepository.GetById(id);

            return _mapper.Map<AccessModel>(access);
        }

        public async Task<ICollection<AccessModel>> GetFilteredAccesses(string query)
        {
            var accesses = await _accessRepository.GetFilteredAccesses(query);

            return _mapper.Map<ICollection<AccessModel>>(accesses);
        }
    }
}
