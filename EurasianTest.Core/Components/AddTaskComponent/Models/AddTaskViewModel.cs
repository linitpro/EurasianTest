using EurasianTest.Core.Components.DictionaryComponents.GetProjectsDictionaryComponent.Models;
using EurasianTest.Core.Components.DictionaryComponents.GetUsersDictionaryComponent.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.AddTaskComponent.Models
{
    public class AddTaskViewModel
    {
        public AddTaskViewModel(): this(new List<UserViewModel>(), new List<ProjectViewModel>()) {}

        public AddTaskViewModel(List<UserViewModel> users, List<ProjectViewModel> projects)
        {
            this.Users = users;
            this.Projects = projects;
        }

        /// <summary>
        /// Описание задачи
        /// </summary>
        public String Description { set; get; }

        /// <summary>
        /// Название задачи
        /// </summary>
        public String Name { set; get; }

        /// <summary>
        /// Проект к которому добавляется задача
        /// </summary>
        public Int64 ProjectId { set; get; }

        /// <summary>
        /// Проекты
        /// </summary>
        public List<ProjectViewModel> Projects { set; get; }

        /// <summary>
        /// Пользователь, для которого назначается задача
        /// </summary>
        public Int64 UserId { set; get; }

        /// <summary>
        /// Пользователи
        /// </summary>
        public List<UserViewModel> Users { set; get; }
    }
}
