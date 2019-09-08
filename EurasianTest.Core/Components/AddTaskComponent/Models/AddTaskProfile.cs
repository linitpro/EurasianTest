using AutoMapper;
using EurasianTest.DAL.Entities.Enums;
using EurasianTest.DAL.Entities.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.AddTaskComponent.Models
{
    public class AddTaskProfile: Profile
    {
        public AddTaskProfile()
        {
            CreateMap<AddTaskViewModel, Task>()
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => TaskStatus.New))
                .ForMember(dest => dest.Started, opt => opt.MapFrom(src => src.GetStarted()))
                .ForMember(dest => dest.Expired, opt => opt.MapFrom(src => src.GetExpired()))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

        }
    }
}
