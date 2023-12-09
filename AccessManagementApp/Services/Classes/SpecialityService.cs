using AccessManagementApp.Entities;
using AccessManagementApp.Models;
using AccessManagementApp.Repositories.Classes;
using AccessManagementApp.Repositories.Interfaces;
using AccessManagementApp.Repository.Facade;
using AccessManagementApp.Repository.Models;
using AccessManagementApp.Services.Interfaces;
using AutoMapper;

namespace AccessManagementApp.Services.Classes
{
    public class SpecialityService : ISpecialityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SpecialityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ICollection<SpecialityModel>> GetAll()
        {
            var specialities = await _unitOfWork.Specialities.GetAll();

            return _mapper.Map<ICollection<SpecialityModel>>(specialities);
        }

        public async Task<SpecialityModel> GetById(int id)
        {
            var speciality = await _unitOfWork.Specialities.GetById(id);

            return _mapper.Map<SpecialityModel>(speciality);
        }

        public async Task<ICollection<SpecialityModel>> GetFilteredSpecialities(string query)
        {
            var specialities = await _unitOfWork.Specialities.GetFilteredSpecialities(query);

            return _mapper.Map<ICollection<SpecialityModel>>(specialities);
        }

        public async Task<SpecialityModel> Update(UpdateSpecialityModel item)
        {
            var speciality = _mapper.Map<Speciality>(item);

            var updatedSpeciality = await _unitOfWork.Specialities.Update(speciality);

            var result = _mapper.Map<SpecialityModel>(updatedSpeciality);

            return result;
        }
    }
}
