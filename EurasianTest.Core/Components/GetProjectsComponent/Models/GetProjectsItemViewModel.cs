using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.GetProjectsComponent.Models
{
    public class GetProjectsItemViewModel
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
