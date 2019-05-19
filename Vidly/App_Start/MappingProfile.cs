using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Models;
using Vidly.Dtos;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(cust => cust.CustomerId , opt => opt.Ignore());

            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(mov => mov.Id , opt => opt.Ignore());

            Mapper.CreateMap<Movie, Movie>()
                .ForMember( mov => mov.DateAdded , opt => opt.Ignore());

            Mapper.CreateMap<Customer, Customer>();
        }
    }
}