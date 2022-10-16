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
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<Patient, PatientGetDto>();
            CreateMap<Patient, PatientPostDto>();
            CreateMap<PatientPostDto, Patient>();
        }
    }
}