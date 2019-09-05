using EurasianTest.DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EurasianTest.Core.Components.DictionaryComponents.GetUsersDictionaryComponent.Models
{
    public class GetUsersDictionaryRequestViewModel
    {
        public GetUsersDictionaryRequestViewModel(): this(Role.User, Role.ProjectAdministrator, Role.Administrator) { }

        public GetUsersDictionaryRequestViewModel(params Role[] roles)
        {
            this.Roles = roles.ToList();
        }

        public List<Role> Roles { set; get; }
    }
}
