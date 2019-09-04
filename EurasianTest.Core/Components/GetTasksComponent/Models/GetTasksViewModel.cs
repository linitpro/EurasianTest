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
        }

        public List<GetTasksItemViewModel> Items { set; get; }
    }
}
