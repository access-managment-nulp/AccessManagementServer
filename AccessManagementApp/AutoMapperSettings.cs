using AccessManagementApp.Entities;
using AccessManagementApp.Models;
using AccessManagementApp.Repository.Models;
using AutoMapper;

namespace AccessManagementApp
{
    public class AutoMapperSettings : Profile
    {
        public AutoMapperSettings()
        {
            // ACCESSES
            CreateMap<Access, AccessModel>()
               .ReverseMap();

            // ACCESS GROUPS
            CreateMap<AccessGroup, AccessGroupModel>()
                .ReverseMap();

            CreateMap<AccessGroup, CreateAccessGroupModel>()
                .ReverseMap();
            
            CreateMap<AccessGroup, UpdateAccessGroupModel>()
                .ReverseMap();

            //SPECIALITIES
            CreateMap<Speciality, SpecialityModel>()
                .ReverseMap();

            CreateMap<Speciality, UpdateSpecialityModel>()
               .ReverseMap();
        }
    }
}
