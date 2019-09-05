using EurasianTest.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.AddTaskComponent.Models
{
    public class AddTaskViewModel
    {
        public AddTaskViewModel()
        {
            this.Users = new List<UserViewModel>();
            this.Projects = new List<ProjectViewModel>();
        }

        /// <summary>
        /// Название задачи
        /// </summary>
        public String Name { set; get; }

        /// <summary>
        /// Описание задачи
        /// </summary>
        public String Description { set; get; }

        /// <summary>
        /// Пользователи
        /// </summary>
        public List<UserViewModel> Users { set; get; }

        /// <summary>
        /// Проекты
        /// </summary>
        public List<ProjectViewModel> Projects { set; get; }

        /// <summary>
        /// Проект к которому добавляется задача
        /// </summary>
        public Int64 ProjectId { set; get; }

        /// <summary>
        /// Пользователь, для которого назначается задача
        /// </summary>
        public Int64 UserId { set; get; }
    }
}
