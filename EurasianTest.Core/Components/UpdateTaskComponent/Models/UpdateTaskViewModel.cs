using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.UpdateTaskComponent.Models
{
    public class UpdateTaskViewModel
    {
        public Int64 Id { set; get; }

        public String Name { set; get; }

        public String Description { set; get; }

        public DateTime Started { set; get; }

        public DateTime Expired { set; get; }
    }
}
