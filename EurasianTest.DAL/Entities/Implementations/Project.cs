using EurasianTest.DAL.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.DAL.Entities.Implementations
{
    public class Project : IEntity
    {
        public Int64 Id { get; set; }
        public Boolean IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Название проекта
        /// </summary>
        public String Name { set; get; }

        /// <summary>
        /// Задачи проекта
        /// </summary>
        public List<Task> Tasks { set; get; }

        public List<ProjectAdministrator> ProjectAdministrators { set; get; }
    }
}
