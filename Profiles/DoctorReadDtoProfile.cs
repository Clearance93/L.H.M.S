using AutoMapper;
using ClinicalApp.Dto;
using ClinicalApp.Models;

namespace ClinicalApp.Profiles
{
    public class DoctorReadDtoProfile : Profile
    {
        public DoctorReadDtoProfile()
        {
            CreateMap<Doctor, DoctorReadDto>();
        }
    }
}