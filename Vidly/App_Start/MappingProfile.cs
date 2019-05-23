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
            // Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();
           
            // Dto to Domain
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(mov => mov.Id , opt => opt.Ignore());

            Mapper.CreateMap<CustomerDto, Customer>()
               .ForMember(cust => cust.CustomerId, opt => opt.Ignore());

            // Domain to Same Domain
            Mapper.CreateMap<Movie, Movie>()
                .ForMember( mov => mov.DateAdded , opt => opt.Ignore());

            Mapper.CreateMap<Customer, Customer>();
        }
    }
}