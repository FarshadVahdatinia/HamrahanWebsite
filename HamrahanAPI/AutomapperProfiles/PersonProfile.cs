using AutoMapper;
using Hamrahan.Models;
using HamrahanTemplate.Application.DTOs;
using HamrahanTemplate.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamrahanAPI.AutomapperProfiles
{
    
    public class PersonProfile : Profile
    {
        
        public PersonProfile()
        {
            CreateMap<Person, ApiUserDTO>().ForMember(c => c.Birthdate, option => option.MapFrom(src => src.Birthdate))
                .ForMember(c => c.EducationGradeName, optio => optio
                       .MapFrom(src => src.EducationGradecode));
              


            CreateMap<ApiUserDTO, Person>();

        }
    }
}
