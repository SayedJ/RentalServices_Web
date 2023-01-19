using System;
using AutoMapper;
using RentalServicesWebApi.Dto;
using RentalServicesWebApi.Models;

namespace RentalServicesWebApi.Configuratioins
{
    public class MappperInitializer : Profile
    {
        public MappperInitializer()
        {
            CreateMap<ApplicationUser, UserDto>().ReverseMap();
            CreateMap<ApplicationUser, LoginUserDto>().ReverseMap();
        }
    }
}

