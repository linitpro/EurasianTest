using AutoMapper;
using EurasianTest.DAL.Entities.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.GetProjectDetailsComponent.Models
{
    public class GetProjectDetailsProfile: Profile
    {
        public GetProjectDetailsProfile()
        {
            CreateMap<Project, GetProjectDetailsViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<User, GetProjectDetailsUserViewModel>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.IsProjectAdministrator, opt => opt.MapFrom(src => src.Role == DAL.Entities.Enums.Role.ProjectAdministrator))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
