using EurasianTest.DAL.Entities.Enums;
using EurasianTest.DAL.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EurasianTest.DAL.Entities.Implementations
{
    public class TaskHistory: IEntity
    {
        public TaskHistory() { }

        public TaskHistory (
            Task oldTask,
            TaskStatus newTaskStatus,
            Int64 changerId,
            Int64 newUserId
            )
        {
            this.IsDeleted = false;
            this.Created = DateTime.Now;
            this.TaskId = oldTask.Id;
            this.OldStatus = oldTask.Status;
            this.NewStatus = newTaskStatus;
            this.UserId = changerId;
            this.OldUserId = oldTask.UserId;
            this.NewUserId = newUserId;
        }

        public Int64 Id { get; set; }
        public Boolean IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }

        /// <summary>
        /// Задача
        /// </summary>
        public Task Task { set; get; }

        /// <summary>
        /// Ссылка на задачу
        /// </summary>
        public Int64 TaskId { set; get; }

        /// <summary>
        /// Старый статус задачи
        /// </summary>
        public TaskStatus OldStatus { set; get; }

        /// <summary>
        /// Новый статус задачи
        /// </summary>
        public TaskStatus NewStatus { set; get; }

        /// <summary>
        /// Пользователь, зменивший статус
        /// </summary>
        public User User { set; get; }

        /// <summary>
        /// Ссылка напользователя, изменившего статус
        /// </summary>
        public Int64 UserId { set; get; }

        /// <summary>
        /// Старый пользователь, на ком была задача
        /// </summary>
        public User OldUser { set; get; }

        /// <summary>
        /// Старый пользователь, на ком была задача
        /// </summary>
        public Int64 OldUserId { set; get; }

        /// <summary>
        /// Новый пользователь, на кого поставили задачу
        /// </summary>
        public User NewUser { set; get; }

        /// <summary>
        /// Новый пользователь, на кого поставили задачу
        /// </summary>
        public Int64 NewUserId { set; get; }
    }
}
