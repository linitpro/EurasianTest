using AutoMapper;
using EurasianTest.DAL.Entities.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.DictionaryComponents.GetUsersDictionaryComponent.Models
{
    public class GetUsersDictionaryProfile: Profile
    {
        public GetUsersDictionaryProfile()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
