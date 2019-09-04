using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.GetProjectsComponent.Models
{
    public class GetProjectsViewModel
    {
        public GetProjectsViewModel()
        {
            this.Projects = new List<GetProjectsItemViewModel>();
        }


        public List<GetProjectsItemViewModel> Projects { set; get; }
    }
}
