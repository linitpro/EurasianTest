using EurasianTest.Core.Components.DictionaryComponents.GetProjectsDictionaryComponent.Models;
using EurasianTest.Core.Components.GetProjectsComponent.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.GetTasksComponent.Models
{
    public class GetTasksViewModel
    {
        public GetTasksViewModel()
        {
            this.Items = new List<GetTasksItemViewModel>();
            this.Projects = new List<GetProjectsItemViewModel>();
        }

        public List<GetProjectsItemViewModel> Projects { set; get; }

        public List<GetTasksItemViewModel> Items { set; get; }
    }
}
