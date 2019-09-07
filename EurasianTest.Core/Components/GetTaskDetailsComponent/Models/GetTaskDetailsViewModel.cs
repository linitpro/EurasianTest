using EurasianTest.Core.Components.DictionaryComponents.GetProjectsDictionaryComponent.Models;
using EurasianTest.Core.Components.DictionaryComponents.GetUsersDictionaryComponent.Models;
using EurasianTest.DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.Core.Components.GetTaskDetailsComponent.Models
{
    public class GetTaskDetailsViewModel
    {
        public List<UserViewModel> Users { set; get; }

        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        public Int64 Id { set; get; }

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
        public ProjectViewModel Project { set; get; }

        /// <summary>
        /// Пользователь, на которого назначена задача
        /// </summary>
        public UserViewModel User { set; get; }

        public Int64 UserId { set; get; }

        public DateTime Started { set; get; }

        public DateTime Expired { set; get; }
    }
}
