using AutoMapper;
using EurasianTest.DAL.Entities.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.DictionaryComponents.GetProjectsDictionaryComponent.Models
{
    public class GetProjectsDictionaryProfile : Profile
    {
        public GetProjectsDictionaryProfile()
        {
            CreateMap<Project, ProjectViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
