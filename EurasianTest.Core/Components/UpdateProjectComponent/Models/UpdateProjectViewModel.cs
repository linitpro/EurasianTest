using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.UpdateProjectComponent.Models
{
    public class UpdateProjectViewModel
    {
        /// <summary>
        /// Идентификатор проекта
        /// </summary>
        public Int64 Id { set; get; }

        /// <summary>
        /// Название проекта
        /// </summary>
        public String Name { set; get; }
    }
}
