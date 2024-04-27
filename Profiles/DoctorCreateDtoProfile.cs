using AutoMapper;
using ClinicalApp.Dto;
using ClinicalApp.Models;

namespace ClinicalApp.Profiles
{
    public class DoctorCreateDtoProfile : Profile
    {
        public DoctorCreateDtoProfile()
        {
            CreateMap<DoctorCreateDto, Doctor>();
        }
    }
}