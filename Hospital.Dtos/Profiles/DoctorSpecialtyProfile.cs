using AutoMapper;
using Hospital.Data.Entities;
using Hospital.Dtos.PostDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Dtos.Profiles
{
    public class DoctorSpecialtyProfile : Profile
    {
        public DoctorSpecialtyProfile()
        {
            CreateMap<DoctorSpecialty, DoctorSpecialtyPostDto>();
            CreateMap<DoctorSpecialtyPostDto, DoctorSpecialty>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom( x => (Guid.NewGuid())));
        }
    }
}
