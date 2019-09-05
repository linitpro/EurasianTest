using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.GetTasksComponent.Models
{
    public class GetTasksItemViewModel
    {
        public Int64 Id { set; get; }

        public String Name { set; get; }

        public DateTime Expired { set; get; }

        public DateTime Started { set; get; }
    }
}
