using AutoMapper;
using EurasianTest.DAL.Entities.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.GetTasksComponent.Models
{
    public class GetTasksProfile: Profile
    {
        public GetTasksProfile()
        {
            CreateMap<Task, GetTasksItemViewModel>()
                .ForMember(dest => dest.Expired, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Started, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));
        }
    }
}
