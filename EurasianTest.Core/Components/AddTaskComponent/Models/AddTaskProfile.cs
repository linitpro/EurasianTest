using AutoMapper;
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
                ;
        }
    }
}
