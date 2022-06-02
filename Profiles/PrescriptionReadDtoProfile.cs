using AutoMapper;
using ClinicalApp.Dto;
using ClinicalApp.Models;

namespace ClinicalApp.Profiles
{
    public class PrescriptionReadDtoProfile : Profile
    {
        public PrescriptionReadDtoProfile()
        {
            CreateMap<PrescriptionReadDto, Prescription>();
        }
    }
}