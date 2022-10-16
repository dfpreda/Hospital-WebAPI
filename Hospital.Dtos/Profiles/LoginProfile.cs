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
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<LoginPostDto, Doctor>();
            CreateMap<LoginPostDto, Patient>();
        }
    }
}
