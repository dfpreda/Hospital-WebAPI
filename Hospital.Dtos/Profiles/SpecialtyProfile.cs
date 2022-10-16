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
    public class SpecialtyProfile : Profile
    {
        public SpecialtyProfile()
        {
            CreateMap<Specialty, SpecialtyGetDto>();
            CreateMap<Specialty, SpecialtyPostDto>();
            CreateMap<SpecialtyPostDto, Specialty>();
        }
    }
}