using EurasianTest.DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.GetUserDetailsComponent.Models
{
    public class GetUserDetailsViewModel
    {
        public Int64 Id { set; get; }

        public String Email { set; get; }

        public Role Role { set; get; }

        
    }
}
