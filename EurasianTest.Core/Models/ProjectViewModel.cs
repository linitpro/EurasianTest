using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Models
{
    public class ProjectViewModel
    {
        /// <summary>
        /// Идентификатор проекта
        /// </summary>
        public Int64 ProjectId { set; get; }

        /// <summary>
        /// Название проекта
        /// </summary>
        public String Name { set; get; }
    }
}
