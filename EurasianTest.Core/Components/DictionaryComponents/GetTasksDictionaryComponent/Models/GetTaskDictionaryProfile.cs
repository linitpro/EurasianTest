using AutoMapper;
using EurasianTest.DAL.Entities.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.DictionaryComponents.GetTasksDictionaryComponent.Models
{
    public class GetTaskDictionaryProfile: Profile
    {
        public GetTaskDictionaryProfile()
        {
            CreateMap<Task, TaskViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
