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
    public class MedicalReportProfile : Profile
    {
        public MedicalReportProfile()
        {
            CreateMap<MedicalReport, MedicalReportGetDto>();
            CreateMap<MedicalReport, MedicalReportPostDto>();
            CreateMap<MedicalReportPostDto, MedicalReport>();
        }
    }
}