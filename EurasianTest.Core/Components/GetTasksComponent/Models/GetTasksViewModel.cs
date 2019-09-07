using EurasianTest.Core.Components.DictionaryComponents.GetProjectsDictionaryComponent.Models;
using EurasianTest.Core.Components.DictionaryComponents.GetUsersDictionaryComponent.Models;
using EurasianTest.Core.Components.GetProjectsComponent.Models;
using EurasianTest.DAL.Entities.Enums;
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

        public List<UserViewModel> Users { set; get; }

        public Int64? ProjectIdFilter { set; get; }

        public Int64? UserIdFilter { set; get; }

        public TaskStatus? TaskStatusFilter { set; get; }
    }
}
