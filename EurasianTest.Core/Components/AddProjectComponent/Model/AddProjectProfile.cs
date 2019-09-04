using AutoMapper;
using EurasianTest.DAL.Entities.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.AddProjectComponent.Model
{
    public class AddProjectProfile: Profile
    {
        public AddProjectProfile()
        {
            CreateMap<AddProjectViewModel, Project>()
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
