using AutoMapper;
using Hospital.Data.Entities;
using Hospital.Dtos.GetDtos;
using Hospital.Dtos.PostDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Dtos.Profiles
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, DoctorGetDto>();
            CreateMap<Doctor, DoctorPostDto>();
            CreateMap<DoctorPostDto, Doctor>()
                .ForMember(dst => dst.DoctorSpecialties, map => map.MapFrom(src => src.DoctorSpecialties == null ? null : src.DoctorSpecialties));
        }
    }
}