using EurasianTest.DAL.Entities.Enums;
using EurasianTest.DAL.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.DAL.Entities.Implementations
{
    public class Task : IEntity
    {
        public Int64 Id { get; set; }
        public Boolean IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Название задачи
        /// </summary>
        public String Name { set; get; }

        /// <summary>
        /// Описание
        /// </summary>
        public String Description { set; get; }

        /// <summary>
        /// Статус
        /// </summary>
        public TaskStatus Status { set; get; }

        /// <summary>
        /// Проект
        /// </summary>
        public Project Project { set; get; }

        /// <summary>
        /// Ссылка на связанный проект
        /// </summary>
        public Int64 ProjectId { set; get; }

        public User User { set; get; }

        public Int64 UserId { set; get; }

        /// <summary>
        /// История задачи
        /// </summary>
        public List<TaskHistory> History { set; get; }
    }
}
