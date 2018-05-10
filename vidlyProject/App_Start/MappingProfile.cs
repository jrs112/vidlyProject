using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using vidlyProject.Dtos;
using vidlyProject.Models;

namespace vidlyProject.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<MoviesDto, Movie>();
            Mapper.CreateMap<Movie, MoviesDto>();
        }
    }
}