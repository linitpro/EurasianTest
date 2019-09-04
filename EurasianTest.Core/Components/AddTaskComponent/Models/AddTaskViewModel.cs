using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.AddTaskComponent.Models
{
    public class AddTaskViewModel
    {
        public String Name { set; get; }

        public String Description { set; get; }

        public Int64 ProjectId { set; get; }
    }
}
