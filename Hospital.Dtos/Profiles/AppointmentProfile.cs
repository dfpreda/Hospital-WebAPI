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
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            CreateMap<Appointment, AppointmentGetDto>();
            CreateMap<Appointment, AppointmentPostDto>();
            CreateMap<AppointmentPostDto, Appointment>();
        }
    }
}