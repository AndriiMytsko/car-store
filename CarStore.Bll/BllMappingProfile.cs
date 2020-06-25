using AutoMapper;
using CarStore.Bll.DTOs;
using CarStore.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore.Bll
{
    public class BllMappingProfile : Profile
    {
        public BllMappingProfile()
        {
            CreateMap<Car, CarDto>().ReverseMap();
        }
    }
}
