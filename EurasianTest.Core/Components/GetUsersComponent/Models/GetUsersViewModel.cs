using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.GetUsersComponent.Models
{
    public class GetUsersViewModel
    {
        public GetUsersViewModel()
        {
            this.Users = new List<GetUsersItemViewModel>();
        }

        public List<GetUsersItemViewModel> Users { set; get; }
    }
}
