using AutoMapper;
using ClinicalApp.Dto;
using ClinicalApp.Models;

namespace ClinicalApp.Profiles
{
    public class PrescriptionCreateDtoProfile : Profile
    {
        public PrescriptionCreateDtoProfile()
        {
            CreateMap<PrescriptionCreateDto, Prescription>();
        }
    }
}