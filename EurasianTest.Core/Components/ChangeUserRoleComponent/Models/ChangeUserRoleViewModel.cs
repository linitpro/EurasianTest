using EurasianTest.DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.ChangeUserRoleComponent.Models
{
    public class ChangeUserRoleViewModel
    {
        public Int64 Id { set; get; }

        public Role Role { set; get; }
    }
}
