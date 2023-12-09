using AccessManagementApp.Entities;
using AccessManagementApp.Repositories.Interfaces;
using AccessManagementApp.Repository.Facade;
using AccessManagementApp.Repository.Models;
using AccessManagementApp.Services.Interfaces;
using AutoMapper;

namespace AccessManagementApp.Services.Classes
{
    public class AccessService : IAccessService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccessService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ICollection<AccessModel>> GetAll()
        {
            var accesses = await _unitOfWork.Accesses.GetAll();
            
            return _mapper.Map<ICollection<AccessModel>>(accesses);
        }

        public async Task<AccessModel> GetById(int id)
        {
            var access = await _unitOfWork.Accesses.GetById(id);

            return _mapper.Map<AccessModel>(access);
        }

        public async Task<ICollection<AccessModel>> GetFilteredAccesses(string query)
        {
            var accesses = await _unitOfWork.Accesses.GetFilteredAccesses(query);

            return _mapper.Map<ICollection<AccessModel>>(accesses);
        }
    }
}
