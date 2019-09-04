using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.AddProjectComponent.Model
{
    public class AddProjectViewModel
    {
        public AddProjectViewModel()
        {
            this.name = "";
        }

        private String name;

        public String Name
        {
            set
            {
                this.name = value;
            }
            get
            {
                return this.name.Trim();
            }
        }
    }
}
